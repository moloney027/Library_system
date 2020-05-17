using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace AuthorBLL
{
    public class AuthorLogic : IAuthorLogic
    {
        private IAuthorDao _authorDao;

        public AuthorLogic(IAuthorDao authorDao)
        {
            _authorDao = authorDao;
        }

        public List<Author> GetAll()
        {
            var listAuthors = _authorDao.GetAll();
            return listAuthors.ToList();
        }

        public string Delete(int idAuthor)
        {
            var  number = _authorDao.Delete(idAuthor);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении автора с id = {idAuthor}";
        }

        public string Create(Author author)
        {
            var  number = _authorDao.Create(author);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении автора";
        }
    }
}