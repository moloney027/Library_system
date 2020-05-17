using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace CityDAL
{
    public class CityDao : ICityDao
    {
        public CityDao()
        {
        }

        public IEnumerable<City> GetAll()
        {
            var listCity = new List<City>();
            const string sqlExpression = "SELECT * FROM City";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listCity.Add(new City(
                            (int)(dataReader["CityID"]), 
                            (string)(dataReader["Title"])));
                }
            }
            return listCity.AsEnumerable();
        }

        public int Delete(int idCity)
        {
            try
            {
                const string sqlExpression = "DELETE FROM City WHERE CityID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idCity);
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

        public int Create(City city)
        {
            try
            {
                const string sqlExpression = "INSERT INTO City (CityID, Title) VALUES (@CityID, @Title)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@CityID", city.CityID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@Title", city.CityTitle);
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