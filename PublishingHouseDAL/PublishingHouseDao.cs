using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace PublishingHouseDAL
{
    public class PublishingHouseDao : IPublishingHouseDao
    {
        public PublishingHouseDao()
        {
        }

        public IEnumerable<PublishingHouse> GetAll()
        {
            var listPublishingHouse = new List<PublishingHouse>();
            const string sqlExpression = "SELECT * FROM PublishingHouse";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listPublishingHouse.Add(new PublishingHouse(
                            (int)(dataReader["ID"]), 
                            (string)(dataReader["Title"]),
                            (int)(dataReader["DateOfEstablishment"])));
                }
            }
            return listPublishingHouse.AsEnumerable();
        }

        public int Delete(int idPublishingHouse)
        {
            try
            {
                const string sqlExpression = "DELETE FROM PublishingHouse WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idPublishingHouse);
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

        public int Create(PublishingHouse publishingHouse)
        {
            try
            {
                const string sqlExpression = "INSERT INTO PublishingHouse (ID, Title, DateOfEstablishment) VALUES (@ID, @Title, @DateOfEstablishment)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@ID", publishingHouse.PublishingHouseID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@Title", publishingHouse.PublishingHouseTitle);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@DateOfEstablishment", publishingHouse.DateOfEstablishment);
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