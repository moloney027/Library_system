﻿using System;
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
                            (int)(dataReader["FineID"]), 
                            (int)(dataReader["BookIssuanceID"]),
                            (int)(dataReader["Amount"]), 
                            (string)(dataReader["Article"])));
                }
            }
            return listFine.AsEnumerable();
        }

        public int Delete(int idFine)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Fine WHERE FineID = @id";
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
                const string sqlExpression = "INSERT INTO Fine (FineID, BookIssuanceID, Amount, Article) VALUES (@FineID, @BookIssuanceID, @Amount, @Article)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@CityID", fine.FineID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@Title", fine.BookIssuanceID);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@Title", fine.FineAmount);
                    command.Parameters.Add(param3);
                    var param4 = new SqlParameter("@Title", fine.FineArticle);
                    command.Parameters.Add(param4);
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