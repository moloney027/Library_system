using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AbstractDAL;
using Entities;
using Utils;

namespace ReviewsDAL
{
    public class ReviewsDao : IReviewsDao
    {
        public ReviewsDao()
        {
        }

        public IEnumerable<Reviews> GetAll()
        {
            var listReviews = new List<Reviews>();
            const string sqlExpression = "SELECT * FROM Reviews";
            using (var connection = Dbsql.GetDbConnection())
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                        listReviews.Add(new Reviews(
                            (int)(dataReader["ReviewsID"]), 
                            (int)(dataReader["BookID"]),
                            (int)(dataReader["LibraryCard"])));
                }
            }
            return listReviews.AsEnumerable();
        }

        public int Delete(int idReviews)
        {
            try
            {
                const string sqlExpression = "DELETE FROM Reviews WHERE LibraryCard = @id";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var idParam = new SqlParameter("@id", idReviews);
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

        public int Create(Reviews reviews)
        {
            try
            {
                const string sqlExpression = "INSERT INTO Reviews (ReviewsID, BookID, LibraryCard) VALUES (@ReviewsID, @BookID, @LibraryCard)";
                using (var connection = Dbsql.GetDbConnection())
                {
                    connection.Open();
                    var command = new SqlCommand(sqlExpression, connection);
                    var param1 = new SqlParameter("@ReviewsID", reviews.ReviewsID);
                    command.Parameters.Add(param1);
                    var param2 = new SqlParameter("@BookID", reviews.BookID);
                    command.Parameters.Add(param2);
                    var param3 = new SqlParameter("@LibraryCard", reviews.LibraryCardForReviews);
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