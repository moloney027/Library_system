using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IAdaptationsDao
    {
        IEnumerable<Adaptations> GetAll();
        int Create(Adaptations adaptation);
        int Delete(int idAdaptation);
    }
}