using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace CityBLL
{
    public class CityLogic : ICityLogic
    {
        private ICityDao _cityDao;

        public CityLogic(ICityDao cityDao)
        {
            _cityDao = cityDao;
        }

        public List<City> GetAll()
        {
            var listCity = _cityDao.GetAll();
            return listCity.ToList();
        }

        public string Delete(int idCity)
        {
            var  number = _cityDao.Delete(idCity);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idCity}";
        }

        public string Create(City city)
        {
            var  number = _cityDao.Create(city);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении города";
        }
    }
}