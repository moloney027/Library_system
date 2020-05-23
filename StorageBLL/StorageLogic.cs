using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;
using StorageDAL;

namespace StorageBLL
{
    public class StorageLogic : IStorageLogic
    {
        private readonly IStorageDao _storageDao;

        public StorageLogic()
        {
            _storageDao = new StorageDao();
        }

        public List<Storage> GetAll()
        {
            var listStorage = _storageDao.GetAll();
            return listStorage.ToList();
        }

        public string Delete(int idStorage)
        {
            var  number = _storageDao.Delete(idStorage);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idStorage}";
        }

        public string Create(Storage storage)
        {
            var  number = _storageDao.Create(storage);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении стеллажа";
        }
    }
}