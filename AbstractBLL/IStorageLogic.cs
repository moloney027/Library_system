using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IStorageLogic
    {
        List<Storage> GetAll();
        string Create(Storage storage);
        string Delete(int idStorage);
    }
}