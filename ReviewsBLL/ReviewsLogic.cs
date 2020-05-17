using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace ReviewsBLL
{
    public class ReviewsLogic : IReviewsLogic
    {
        private IReviewsDao _reviewsDao;

        public ReviewsLogic(IReviewsDao reviewsDao)
        {
            _reviewsDao = reviewsDao;
        }

        public List<Reviews> GetAll()
        {
            var listReviews = _reviewsDao.GetAll();
            return listReviews.ToList();
        }

        public string Delete(int idReviews)
        {
            var  number = _reviewsDao.Delete(idReviews);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idReviews}";
        }

        public string Create(Reviews reviews)
        {
            var  number = _reviewsDao.Create(reviews);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении отзыва";
        }
    }
}