using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IAuthorsAndBooksDao
    {
        IEnumerable<AuthorsAndBooks> GetAll();
        int Create(AuthorsAndBooks authorAndBook);
        int Delete(int idAuthorsAndBooks);
    }
}