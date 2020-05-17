using System.Collections.Generic;
using System.Linq;
using AbstractBLL;
using AbstractDAL;
using Entities;

namespace GenreBLL
{
    public class GenreLogic : IGenreLogic
    {
        private IGenreDao _genreDao;

        public GenreLogic(IGenreDao genreDao)
        {
            _genreDao = genreDao;
        }

        public List<Genre> GetAll()
        {
            var listGenre = _genreDao.GetAll();
            return listGenre.ToList();
        }

        public string Delete(int idGenre)
        {
            var  number = _genreDao.Delete(idGenre);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idGenre}";
        }

        public string Create(Genre genre)
        {
            var  number = _genreDao.Create(genre);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении жанра";
        }
    }
}