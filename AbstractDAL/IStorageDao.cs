using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IStorageDao
    {
        IEnumerable<Storage> GetAll();
        int Create(Storage storage);
        int Delete(int idStorage); 
    }
}