using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace ReadersBLL
{
    public class ReadersLogic : IReadersLogic
    {
        private IReadersDao _readersDao;

        public ReadersLogic(IReadersDao readersDao)
        {
            _readersDao = readersDao;
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