namespace Entities
{
    public class Book
    {
        public Book(string titleBook, int yearBook, int idPH, string langBook)
        {
            BookTitle = titleBook;
            YearOfWriting = yearBook;
            PublishingHouseID = idPH;
            LanguageBook = langBook;
        }

        public Book(int idBook, string titleBook, int yearBook, int idPH, string langBook)
        {
            BookID = idBook;
            BookTitle = titleBook;
            YearOfWriting = yearBook;
            PublishingHouseID = idPH;
            LanguageBook = langBook;
        }

        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public int YearOfWriting { get; set; }
        public int PublishingHouseID { get; set; }
        public string LanguageBook { get; set; }
    }
}