using AbstractBLL;
using AbstractDAL;
using Entities;
using GenreDAL;
using System.Collections.Generic;
using System.Linq;

namespace GenreBLL
{
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreDao _genreDao;

        public GenreLogic()
        {
            _genreDao = new GenreDao();
        }

        public List<Genre> GetAll()
        {
            IEnumerable<Genre> listGenre = _genreDao.GetAll();
            return listGenre.ToList();
        }

        public string Delete(int idGenre)
        {
            int number = _genreDao.Delete(idGenre);
            return number >= 0 ? $"Удаление успешно" : $"Ошибка при удалении с id = {idGenre}";
        }

        public string Create(Genre genre)
        {
            int number = _genreDao.Create(genre);
            return number > 0 ? $"Добавление успешно" : $"Ошибка при добавлении жанра";
        }
    }
}