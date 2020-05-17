using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace AuthorsAndBooksBLL
{
    public class AuthorsAndBooksLogic : IAuthorsAndBooksLogic
    {
        private IAuthorsAndBooksDao _authorsAndBooksDao;

        public AuthorsAndBooksLogic(IAuthorsAndBooksDao authorsAndBooksDao)
        {
            _authorsAndBooksDao = authorsAndBooksDao;
        }

        public List<AuthorsAndBooks> GetAll()
        {
            var listAuthorsAndBooks = _authorsAndBooksDao.GetAll();
            return listAuthorsAndBooks.ToList();
        }

        public string Delete(int idAuthorsAndBooks)
        {
            var  number = _authorsAndBooksDao.Delete(idAuthorsAndBooks);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idAuthorsAndBooks}";
        }

        public string Create(AuthorsAndBooks authorsAndBooks)
        {
            var  number = _authorsAndBooksDao.Create(authorsAndBooks);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении автора";
        }
    }
}