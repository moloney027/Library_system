using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace AuthorDAL
{
    public class AuthorDao : IAuthorDao
    {
        public AuthorDao()
        {
        }

        public IEnumerable<Author> GetAll()
        {
            var listAuthor = new List<Author>();
            const string sqlExpression = "SELECT * FROM Author";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listAuthor.Add(new Author(
                            (int)(dataReader["ID"]), 
                            (string)(dataReader["FullName"]),
                            (DateTime)(dataReader["DateOfBirth"]), 
                            (string)(dataReader["PlaceOfBirth"])));
                }
            }
            return listAuthor.AsEnumerable();
        }

        public int Delete(int idAuthor)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Author WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idAuthor);
                    command.Parameters.Add(idParam);
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }

        public int Create(Author author)
        {
            try
            {
                var sqlExpression = "INSERT INTO Author (ID, FullName, DateOfBirth, PlaceOfBirth) VALUES (@ID, @FullName, @DateOfBirth, @PlaceOfBirth)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@ID", author.AuthorID);
                    command.Parameters.Add(idParam);
                    var fullNameParam = new SqlParameter("@FullName", author.AuthorFullName);
                    command.Parameters.Add(fullNameParam);
                    var dateParam = new SqlParameter("@DateOfBirth", author.AuthorDateOfBirth);
                    command.Parameters.Add(dateParam);
                    var placeParam = new SqlParameter("@PlaceOfBirth", author.AuthorPlaceOfBirth);
                    command.Parameters.Add(placeParam);
                    var number = command.ExecuteNonQuery();
                    return number;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                return -1;
            }
        }
    }
}