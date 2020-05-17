using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IBookIssuanceDao
    {
        IEnumerable<BookIssuance> GetAll();
        int Create(BookIssuance bookIssuance);
        int Delete(int idBookIssuance);
    }
}