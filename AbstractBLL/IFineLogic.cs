using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IFineLogic
    {
        List<Fine> GetAll();
        string Create(Fine fine);
        string Delete(int idFine);
    }
}