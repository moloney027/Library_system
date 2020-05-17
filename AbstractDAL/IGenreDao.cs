using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IGenreDao
    {
        IEnumerable<Genre> GetAll();
        int Create(Genre genre);
        int Delete(int idGenre);
    }
}