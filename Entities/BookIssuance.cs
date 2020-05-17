using System;

namespace Entities
{
    public class BookIssuance
    {
        public BookIssuance(){}

        public BookIssuance(int idBI, DateTime dateIssue, DateTime dateCompl, int idReader, int idBookCopy)
        {
            BookIssuanceID = idBI;
            DateOfIssue = dateIssue;
            DateOfCompletion = dateCompl;
            LibraryCard = idReader;
            BookCopyID = idBookCopy;
        }

        public int BookIssuanceID { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public int LibraryCard { get; set; }
        public int BookCopyID { get; set; }
        
    }
}