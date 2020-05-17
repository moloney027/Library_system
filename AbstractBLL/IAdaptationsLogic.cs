using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IAdaptationsLogic
    {
        List<Adaptations> GetAll();
        string Create(Adaptations adaptations);
        string Delete(int idAdaptations);
    }
}