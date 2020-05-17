namespace Entities
{
    public class BookCopy
    {
        public BookCopy(){}

        public BookCopy(int idBookCopy, int idBook, int idStorage)
        {
            BookCopyID = idBookCopy;
            BookID = idBook;
            StorageID = idStorage;
        }

        public int BookCopyID { get; set; }
        public int BookID { get; set; }
        public int StorageID { get; set; }
    }
}