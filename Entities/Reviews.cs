namespace Entities
{
    public class Reviews
    {
        public Reviews(){}

        public Reviews(int idReview, int idBook, int idReader)
        {
            ReviewsID = idReview;
            BookID = idBook;
            LibraryCardForReviews = idReader;
        }

        public int ReviewsID { get; set; }
        public int BookID { get; set; }
        public int LibraryCardForReviews { get; set; }
    }
}