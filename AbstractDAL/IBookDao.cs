using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IBookDao
    {
        IEnumerable<Book> GetAll();
        int Create(Book book);
        int Delete(int idBook);
    }
}