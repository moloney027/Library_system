using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface ICityDao
    {
        IEnumerable<City> GetAll();
        int Create(City city);
        int Delete(int idCity);
    }
}