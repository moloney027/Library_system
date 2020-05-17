using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IGenreLogic
    {
        List<Genre> GetAll();
        string Create(Genre genre);
        string Delete(int idGenre);
    }
}