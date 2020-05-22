using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using BookIssuanceDAL;
using Entities;

namespace BookIssuanceBLL
{
    public class BookIssuanceLogic : IBookIssuanceLogic
    {
        private readonly BookIssuanceDao _bookIssuanceDao;

        public BookIssuanceLogic()
        {
            _bookIssuanceDao = new BookIssuanceDao();
        }

        public BookIssuance GetById(int id)
        {
            return _bookIssuanceDao.GetById(id);
        }
        public List<BookIssuance> GetAll()
        {
            var listBookIssuance = _bookIssuanceDao.GetAll();
            return listBookIssuance.ToList();
        }

        public string Delete(int idBookIssuance)
        {
            var  number = _bookIssuanceDao.Delete(idBookIssuance);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idBookIssuance}";
        }

        public string Create(BookIssuance bookIssuance)
        {
            var  number = _bookIssuanceDao.Create(bookIssuance);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении информации о выдаче книги";
        }
    }
}