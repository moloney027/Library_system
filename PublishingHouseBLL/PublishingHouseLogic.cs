using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;
using PublishingHouseDAL;

namespace PublishingHouseBLL
{
    public class PublishingHouseLogic : IPublishingHouseLogic
    {
        private IPublishingHouseDao _publishingHouseDao;

        public PublishingHouseLogic()
        {
            _publishingHouseDao = new PublishingHouseDao();
        }

        public List<PublishingHouse> GetAll()
        {
            var listPublishingHouse = _publishingHouseDao.GetAll();
            return listPublishingHouse.ToList();
        }

        public string Delete(int idPublishingHouse)
        {
            var  number = _publishingHouseDao.Delete(idPublishingHouse);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idPublishingHouse}";
        }

        public string Create(PublishingHouse publishingHouse)
        {
            var  number = _publishingHouseDao.Create(publishingHouse);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении издательства";
        }
    }
}