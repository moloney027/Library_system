using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IAuthorLogic
    {
        List<Author> GetAll();
        string Create(Author author);
        string Delete(int idAuthor);
    }
}