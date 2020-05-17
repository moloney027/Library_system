namespace Entities
{
    public class AuthorsAndBooks
    {
        public AuthorsAndBooks(){}

        public AuthorsAndBooks(int idAB, int idAuthor, int idBook)
        {
            IDAuthorsAndBooks = idAB;
            AuthorID = idAuthor;
            BookID = idBook;
        }

        public int IDAuthorsAndBooks { get; set; }
        public int AuthorID { get; set; }
        public int BookID { get; set; }
    }
}