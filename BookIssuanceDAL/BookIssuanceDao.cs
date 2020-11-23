using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace BookIssuanceDAL
{
    public class BookIssuanceDao : IBookIssuanceDao
    {
        public BookIssuance GetById(int id)
        {
            const string sqlExpression =
                "SELECT ID, DateOfIssue, DateOfCompletion, LibraryCard, BookCopyID FROM BookIssuance where ID = @id";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                command.Parameters.AddWithValue("@id", id);
                using (var dataReader = command.ExecuteReader())
                {
                    dataReader.Read();
                    return new BookIssuance(
                        (int) (dataReader["ID"]),
                        (DateTime) (dataReader["DateOfIssue"]),
                        (DateTime) (dataReader["DateOfCompletion"]),
                        (int) (dataReader["LibraryCard"]),
                        (int) (dataReader["BookCopyID"]));
                }
            }
        }

        public IEnumerable<BookIssuance> GetAll()
        {
            var listBookIssuance = new List<BookIssuance>();
            const string sqlExpression = "SELECT * FROM BookIssuance";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listBookIssuance.Add(new BookIssuance(
                            (int) (dataReader["ID"]),
                            (DateTime) (dataReader["DateOfIssue"]),
                            (DateTime) (dataReader["DateOfCompletion"]),
                            (int) (dataReader["LibraryCard"]),
                            (int) (dataReader["BookCopyID"])));
                }
            }

            return listBookIssuance.AsEnumerable();
        }

        public int Delete(int idBookIssuance)
        {
            try
            {
                const string sqlExpression = "DELETE FROM BookIssuance WHERE ID = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idBookIssuance);
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

        public int Create(BookIssuance bookIssuance)
        {
            try
            {
                const string sqlExpression =
                    "INSERT INTO BookIssuance (ID, DateOfIssue, DateOfCompletion, LibraryCard, BookCopyID) VALUES (@ID, @DateOfIssue, @DateOfCompletion, @LibraryCard, @BookCopyID)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    command.Parameters.AddWithValue("@ID", bookIssuance.BookIssuanceID);
                    command.Parameters.AddWithValue("@DateOfIssue", bookIssuance.DateOfIssue);
                    command.Parameters.AddWithValue("@DateOfCompletion", bookIssuance.DateOfCompletion);
                    command.Parameters.AddWithValue("@LibraryCard", bookIssuance.LibraryCard);
                    command.Parameters.AddWithValue("@BookCopyID", bookIssuance.BookCopyID);
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