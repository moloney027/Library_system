using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace FineDAL
{
    public class FineDao : IFineDao
    {
        public FineDao()
        {
        }

        public IEnumerable<Fine> GetAll()
        {
            var listFine = new List<Fine>();
            const string sqlExpression = "SELECT * FROM Fine";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listFine.Add(new Fine(
                            (int) (dataReader["ID"]),
                            (int) (dataReader["BookIssuanceID"]),
                            (Byte) (dataReader["Amount"])));
                }
            }
            return listFine.AsEnumerable();
        }

        public int Delete(int idFine)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Fine WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idFine);
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

        public int Create(Fine fine)
        {
            try
            {
                const string sqlExpression = "INSERT INTO Fine (ID, BookIssuanceID, Amount) VALUES (@ID, @BookIssuanceID, @Amount)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@ID", fine.FineID);
                    command.Parameters.AddWithValue("@BookIssuanceID", fine.BookIssuanceID);
                    command.Parameters.AddWithValue("@Amount", fine.FineAmount);
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