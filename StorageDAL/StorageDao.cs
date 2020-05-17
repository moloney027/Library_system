using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace StorageDAL
{
    public class StorageDao : IStorageDao
    {
        public StorageDao()
        {
        }

        public IEnumerable<Storage> GetAll()
        {
            var listStorage = new List<Storage>();
            const string sqlExpression = "SELECT * FROM Storage";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listStorage.Add(new Storage(
                            (int)(dataReader["StorageID"]), 
                            (int)(dataReader["Rack"]),
                            (int)(dataReader["Shelf"])));
                }
            }
            return listStorage.AsEnumerable();
        }

        public int Delete(int idStorage)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Storage WHERE StorageID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idStorage);
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

        public int Create(Storage storage)
        {
            try
            {
                const string sqlExpression = "INSERT INTO Storage (StorageID, Rack, Shelf) VALUES (@StorageID, @Rack, @Shelf)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@StorageID", storage.StorageID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@Rack", storage.StorageRack);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@Shelf", storage.StorageShelf);
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