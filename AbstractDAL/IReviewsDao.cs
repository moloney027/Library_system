using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IReviewsDao
    {
        IEnumerable<Reviews> GetAll();
        int Create(Reviews reviews);
        int Delete(int idReviews); 
    }
}