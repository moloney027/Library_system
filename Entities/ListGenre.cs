namespace Entities
{
    public class ListGenre
    {
        public ListGenre() { }

        public ListGenre(int idLG, int idBook, int idGenre)
        {
            IDListGenre = idLG;
            BookID = idBook;
            GenreID = idGenre;
        }

        public int IDListGenre { get; set; }
        public int BookID { get; set; }
        public int GenreID { get; set; }
    }
}