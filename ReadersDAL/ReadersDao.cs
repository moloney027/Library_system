using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace ReadersDAL
{
    public class ReadersDao : IReadersDao
    {
        public Readers GetById(int id)
        {
            const string sqlExpression =
                "SELECT ID, FullName, Age, AddressReader FROM Readers where ID = @id";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", id);
                using (var dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    return new Readers(
                        (int) (dataReader["ID"]),
                        (string) (dataReader["FullName"]),
                        (int) (dataReader["Age"]),
                        (string) (dataReader["AddressReader"]));
                }
            }
        }

        public IEnumerable<Readers> GetAll()
        {
            var listReaders = new List<Readers>();
            const string sqlExpression = "SELECT * FROM Readers";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listReaders.Add(new Readers(
                            (int) (dataReader["ID"]),
                            (string) (dataReader["FullName"]),
                            (int) (dataReader["Age"]),
                            (string) (dataReader["AddressReader"])));
                }
            }

            return listReaders.AsEnumerable();
        }

        public int Delete(int idReaders)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Readers WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idReaders);
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

        public int Create(Readers readers)
        {
            try
            {
                const string sqlExpression =
                    "INSERT INTO Readers (ID, FullName, Age, AddressReader) VALUES (@ID, @FullName, @Age, @AddressReader)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@ID", readers.LibraryCardReader);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@FullName", readers.ReaderFullName);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@Age", readers.ReaderAge);
                    command.Parameters.Add(param3);
                    var param4 = new SqlParameter("@AddressReader", readers.ReaderAddress);
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