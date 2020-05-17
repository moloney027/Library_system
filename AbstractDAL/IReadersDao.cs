using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IReadersDao
    {
        IEnumerable<Readers> GetAll();
        int Create(Readers readers);
        int Delete(int idReaders);
    }
}