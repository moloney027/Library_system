using System;

namespace Entities
{
    public class Author
    {
        public Author(){}

        public Author(int idAuthor, string authorFullName, DateTime dateBirth, string placeBirth)
        {
            AuthorID = idAuthor;
            AuthorFullName = authorFullName;
            AuthorDateOfBirth = dateBirth;
            AuthorPlaceOfBirth = placeBirth;
        }

        public int AuthorID { get; set; }
        public string AuthorFullName { get; set; }
        public DateTime AuthorDateOfBirth { get; set; }
        public string AuthorPlaceOfBirth { get; set; }
    }
}