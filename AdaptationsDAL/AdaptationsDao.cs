using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace AdaptationsDAL
{
    public class AdaptationsDao : IAdaptationsDao
    {
        public AdaptationsDao()
        {
        }
        
        public IEnumerable<Adaptations> GetAll()
        {
            var listAdaptations = new List<Adaptations>();
            const string sqlExpression = "SELECT * FROM Adaptations";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listAdaptations.Add(new Adaptations(
                            (int)(dataReader["ID"]), 
                            (int)(dataReader["BookID"]),
                            (string)(dataReader["TypeAdaptation"]), 
                            (int)(dataReader["Year_"]), 
                            (string)(dataReader["Country"])));
                }
            }
            return listAdaptations.AsEnumerable();
        }

        public int Delete(int idAdaptation)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Adaptations WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idAdaptation);
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

        public int Create(Adaptations adaptation)
        {
            try
            {
                var sqlExpression = "INSERT INTO Adaptations " + 
                                    "(ID, BookID, TypeAdaptation, Year_, Country) " + 
                                    "VALUES (@ID, @BookID, @TypeAdaptation, @Year_, @Country)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@ID", adaptation.AdaptationID);
                    command.Parameters.Add(idParam);
                    var bookIdParam = new SqlParameter("@BookID", adaptation.BookID);
                    command.Parameters.Add(bookIdParam);
                    var typeParam = new SqlParameter("@TypeAdaptation", adaptation.AdaptationType);
                    command.Parameters.Add(typeParam);
                    var yearParam = new SqlParameter("@Year_", adaptation.AdaptationYear);
                    command.Parameters.Add(yearParam);
                    var countryParam = new SqlParameter("@Country", adaptation.AdaptationCountry);
                    command.Parameters.Add(countryParam);
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