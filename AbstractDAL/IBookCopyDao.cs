using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IBookCopyDao
    {
        IEnumerable<BookCopy> GetAll();
        int Create(BookCopy bookCopy);
        int Delete(int idBookCopy);
    }
}