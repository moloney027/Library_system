using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;
using ReadersDAL;

namespace ReadersBLL
{
    public class ReadersLogic : IReadersLogic
    {
        private ReadersDao _readersDao;

        public ReadersLogic()
        {
            _readersDao = new ReadersDao();
        }

        public Readers GetById(int id)
        {
            return _readersDao.GetById(id);
        }

        public List<Readers> GetAll()
        {
            var listReaders = _readersDao.GetAll();
            return listReaders.ToList();
        }

        public string Delete(int idReaders)
        {
            var  number = _readersDao.Delete(idReaders);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idReaders}";
        }

        public string Create(Readers readers)
        {
            var  number = _readersDao.Create(readers);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении читателя";
        }
    }
}