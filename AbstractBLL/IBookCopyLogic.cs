using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IBookCopyLogic
    {
        List<BookCopy> GetAll();
        string Create(BookCopy bookCopy);
        string Delete(int idBookCopy);
    }
}