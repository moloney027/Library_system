using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IAuthorsAndBooksLogic
    {
        List<AuthorsAndBooks> GetAll();
        string Create(AuthorsAndBooks authorsAndBooks);
        string Delete(int idAuthorsAndBooks);
    }
}