using AbstractBLL;
using AbstractDAL;
using AuthorsAndBooksDAL;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace AuthorsAndBooksBLL
{
    public class AuthorsAndBooksLogic : IAuthorsAndBooksLogic
    {
        private readonly IAuthorsAndBooksDao _authorsAndBooksDao;

        public AuthorsAndBooksLogic()
        {
            _authorsAndBooksDao = new AuthorsAndBooksDao();
        }

        public List<AuthorsAndBooks> GetAll()
        {
            IEnumerable<AuthorsAndBooks> listAuthorsAndBooks = _authorsAndBooksDao.GetAll();
            return listAuthorsAndBooks.ToList();
        }

        public string Delete(int idAuthorsAndBooks)
        {
            int number = _authorsAndBooksDao.Delete(idAuthorsAndBooks);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idAuthorsAndBooks}";
        }

        public string Create(AuthorsAndBooks authorsAndBooks)
        {
            int number = _authorsAndBooksDao.Create(authorsAndBooks);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении автора";
        }
    }
}