using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IFineDao
    {
        IEnumerable<Fine> GetAll();
        int Create(Fine fine);
        int Delete(int idFine);
    }
}