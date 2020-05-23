using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using BookCopyDAL;
using Entities;

namespace BookCopyBLL
{
    public class BookCopyLogic : IBookCopyLogic
    {
        private readonly IBookCopyDao _bookCopyDao;

        public BookCopyLogic()
        {
            _bookCopyDao = new BookCopyDao();
        }

        public List<BookCopy> GetAll()
        {
            var listBookCopy = _bookCopyDao.GetAll();
            return listBookCopy.ToList();
        }

        public string Delete(int idBookCopy)
        {
            var  number = _bookCopyDao.Delete(idBookCopy);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idBookCopy}";
        }

        public string Create(BookCopy bookCopy)
        {
            var  number = _bookCopyDao.Create(bookCopy);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении экземпляра книги";
        }
    }
}