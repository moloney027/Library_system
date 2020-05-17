using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace AdaptationsBLL
{
    public class AdaptationsLogic : IAdaptationsLogic
    {
        private IAdaptationsDao _adaptationsDao;

        public AdaptationsLogic(IAdaptationsDao adaptationsDao)
        {
            _adaptationsDao = adaptationsDao;
        }

        public List<Adaptations> GetAll()
        {
            var listAdaptations = _adaptationsDao.GetAll();
            return listAdaptations.ToList();
        }

        public string Delete(int idAdaptations)
        {
            var  number = _adaptationsDao.Delete(idAdaptations);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении адаптации с id = {idAdaptations}";
        }

        public string Create(Adaptations adaptation)
        {
            var  number = _adaptationsDao.Create(adaptation);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении адаптации";
        }
    }
}