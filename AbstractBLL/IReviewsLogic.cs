using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IReviewsLogic
    {
        List<Reviews> GetAll();
        string Create(Reviews reviews);
        string Delete(int idReviews);
    }
}