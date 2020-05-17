using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace AuthorsAndBooksDAL
{
    public class AuthorsAndBooksDao : IAuthorsAndBooksDao
    {
        public AuthorsAndBooksDao()
        {
            
        }
        
        public IEnumerable<AuthorsAndBooks> GetAll()
        {
            var listAuthorsAndBooks = new List<AuthorsAndBooks>();
            const string sqlExpression = "SELECT * FROM AuthorsAndBooks";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listAuthorsAndBooks.Add(new AuthorsAndBooks(
                            (int)(dataReader["ID"]), 
                            (int)(dataReader["AuthorID"]),
                            (int)(dataReader["BookID"])));
                }
            }
            return listAuthorsAndBooks.AsEnumerable();
        }

        public int Delete(int idAuthorsAndBooks)
        {
            try
            {
                const string sqlExpression = "DELETE FROM AuthorsAndBooks WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idAuthorsAndBooks);
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

        public int Create(AuthorsAndBooks authorAndBook)
        {
            try
            {
                const string sqlExpression = "INSERT INTO AuthorsAndBooks (ID, AuthorID, BookID) VALUES (@ID, @AuthorID, @BookID)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@ID", authorAndBook.IDAuthorsAndBooks);
                    command.Parameters.Add(idParam);
                    var idAuthorParam = new SqlParameter("@AuthorID", authorAndBook.AuthorID);
                    command.Parameters.Add(idAuthorParam);
                    var idBookParam = new SqlParameter("@BookID", authorAndBook.BookID);
                    command.Parameters.Add(idBookParam);
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