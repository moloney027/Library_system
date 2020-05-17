using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IAuthorDao
    {
        IEnumerable<Author> GetAll();
        int Create(Author author);
        int Delete(int idAuthor);
    }
}