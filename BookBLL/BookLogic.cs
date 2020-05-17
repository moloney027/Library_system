using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace BookBLL
{
    public class BookLogic : IBookLogic
    {
        private IBookDao _bookDao;

        public BookLogic(IBookDao bookCopyDao)
        {
            _bookDao = bookCopyDao;
        }

        public List<Book> GetAll()
        {
            var listBook = _bookDao.GetAll();
            return listBook.ToList();
        }

        public string Delete(int idBook)
        {
            var  number = _bookDao.Delete(idBook);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idBook}";
        }

        public string Create(Book book)
        {
            var  number = _bookDao.Create(book);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении книги";
        }
    }
}