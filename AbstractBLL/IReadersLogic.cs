using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IReadersLogic
    {
        List<Readers> GetAll();
        string Create(Readers readers);
        string Delete(int idReaders);
    }
}