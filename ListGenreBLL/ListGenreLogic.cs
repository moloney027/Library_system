using AbstractBLL;
using AbstractDAL;
using Entities;
using ListGenreDAL;
using System.Collections.Generic;
using System.Linq;

namespace ListGenreBLL
{
    public class ListGenreLogic : IListGenreLogic
    {
        private readonly IListGenreDao _listGenreDao;

        public ListGenreLogic()
        {
            _listGenreDao = new ListGenreDao();
        }

        public List<ListGenre> GetAll()
        {
            IEnumerable<ListGenre> listListGenre = _listGenreDao.GetAll();
            return listListGenre.ToList();
        }

        public string Delete(int idListGenre)
        {
            int number = _listGenreDao.Delete(idListGenre);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idListGenre}";
        }

        public string Create(ListGenre listGenre)
        {
            int number = _listGenreDao.Create(listGenre);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении списка жанров";
        }
    }
}