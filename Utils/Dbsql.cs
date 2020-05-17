using System;
using System.Data.SqlClient;

namespace Utils
{
    public class Dbsql
    {
        private static string _connString;

        private static void Build(string datasource, string database)
        {
            _connString = $@"Server= {datasource}; Database= {database}; Integrated Security=True";
        }

        public static SqlConnection GetDbConnection()
        {
            if (_connString is null)
            {
                Build("127.0.0.1", "LibrarySystem");
            }
            var conn = new SqlConnection(_connString ?? throw new Exception("Нет данных для подключения к бд :("));
            return conn;
        }
    }
}