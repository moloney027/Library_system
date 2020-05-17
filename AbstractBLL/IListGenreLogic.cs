using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IListGenreLogic
    {
        List<ListGenre> GetAll();
        string Create(ListGenre listGenre);
        string Delete(int idListGenre);
    }
}