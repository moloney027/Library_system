using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IBookLogic
    {
        List<Book> GetAll();
        string Create(Book book);
        string Delete(int idBook);
    }
}