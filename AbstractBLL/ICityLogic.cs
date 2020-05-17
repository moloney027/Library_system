using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface ICityLogic
    {
        List<City> GetAll();
        string Create(City city);
        string Delete(int idCity);
    }
}