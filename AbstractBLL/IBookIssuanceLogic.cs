using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IBookIssuanceLogic
    {
        List<BookIssuance> GetAll();
        string Create(BookIssuance bookIssuance);
        string Delete(int idBookIssuance);
    }
}