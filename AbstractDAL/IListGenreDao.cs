using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IListGenreDao
    {
        IEnumerable<ListGenre> GetAll();
        int Create(ListGenre listGenre);
        int Delete(int idListGenre);
    }
}