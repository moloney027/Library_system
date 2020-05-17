using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace ListGenreBLL
{
    public class ListGenreLogic : IListGenreLogic
    {
        private IListGenreDao _listGenreDao;

        public ListGenreLogic(IListGenreDao listGenreDao)
        {
            _listGenreDao = listGenreDao;
        }

        public List<ListGenre> GetAll()
        {
            var listListGenre = _listGenreDao.GetAll();
            return listListGenre.ToList();
        }

        public string Delete(int idListGenre)
        {
            var  number = _listGenreDao.Delete(idListGenre);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idListGenre}";
        }

        public string Create(ListGenre listGenre)
        {
            var  number = _listGenreDao.Create(listGenre);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении списка жанров";
        }
    }
}