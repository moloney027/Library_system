using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace FineBLL
{
    public class FineLogic : IFineLogic
    {
        private IFineDao _fineDao;

        public FineLogic(IFineDao fineDao)
        {
            _fineDao = fineDao;
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