namespace WebApplication.Models
{
    public class BookCopyModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int StorageId { get; set; }
        public int Rack { get; set; }
        public int Shelf { get; set; }

        public BookCopyModel(int id, int bookId, string bookTitle, int storageId, int rack, int shelf)
        {
            Id = id;
            BookId = bookId;
            BookTitle = bookTitle;
            StorageId = storageId;
            Rack = rack;
            Shelf = shelf;
        }
    }
}