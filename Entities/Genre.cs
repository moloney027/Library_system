namespace Entities
{
    public class Genre
    {
        public Genre(){}

        public Genre(int idGenre, string genreTitle)
        {
            GenreID = idGenre;
            GenreTitle = genreTitle;
        }

        public int GenreID { get; set; }
        public string GenreTitle { get; set; }
    }
}