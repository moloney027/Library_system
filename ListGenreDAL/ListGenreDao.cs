using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace ListGenreDAL
{
    public class ListGenreDao : IListGenreDao
    {
        public ListGenreDao()
        {
        }

        public IEnumerable<ListGenre> GetAll()
        {
            var listListGenre = new List<ListGenre>();
            const string sqlExpression = "SELECT * FROM ListGenre";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listListGenre.Add(new ListGenre(
                            (int)(dataReader["ID"]), 
                            (int)(dataReader["BookID"]),
                            (int)(dataReader["GenreID"])));
                }
            }
            return listListGenre.AsEnumerable();
        }

        public int Delete(int idListGenre)
        {
            try
            {
                const string sqlExpression = "DELETE FROM ListGenre WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idListGenre);
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

        public int Create(ListGenre listGenre)
        {
            try
            {
                const string sqlExpression = "INSERT INTO ListGenre (ID, BookID, GenreID) VALUES (@ID, @BookID, @GenreID)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@ID", listGenre.IDListGenre);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@BookID", listGenre.BookID);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@GenreID", listGenre.GenreID);
                    command.Parameters.Add(param3);
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