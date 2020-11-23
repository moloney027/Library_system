using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace GenreDAL
{
    public class GenreDao : IGenreDao
    {
        public GenreDao()
        {
        }

        public IEnumerable<Genre> GetAll()
        {
            var listGenre = new List<Genre>();
            const string sqlExpression = "SELECT * FROM Genre";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listGenre.Add(new Genre(
                            (int)(dataReader["ID"]), 
                            (string)(dataReader["Title"])));
                }
            }
            return listGenre.AsEnumerable();
        }

        public int Delete(int idGenre)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Genre WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idGenre);
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

        public int Create(Genre genre)
        {
            try
            {
                const string sqlExpression = "INSERT INTO Genre (ID, Title) VALUES (@ID, @Title)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@ID", genre.GenreID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@Title", genre.GenreTitle);
                    command.Parameters.Add(param2);
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