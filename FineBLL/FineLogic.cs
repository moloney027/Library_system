using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;
using FineDAL;

namespace FineBLL
{
    public class FineLogic : IFineLogic
    {
        private readonly IFineDao _fineDao;

        public FineLogic()
        {
            _fineDao = new FineDao();
        }

        public List<Fine> GetAll()
        {
            var listFine = _fineDao.GetAll();
            return listFine.ToList();
        }

        public string Delete(int idFine)
        {
            var  number = _fineDao.Delete(idFine);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idFine}";
        }

        public string Create(Fine fine)
        {
            var  number = _fineDao.Create(fine);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении штрафа";
        }
    }
}