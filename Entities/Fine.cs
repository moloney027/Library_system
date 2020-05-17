namespace Entities
{
    public class Fine
    {
        public Fine(){}

        public Fine(int idFine, int idBI, int amountFine, string articleFine)
        {
            FineID = idFine;
            BookIssuanceID = idBI;
            FineAmount = amountFine;
            FineArticle = articleFine;
        }

        public int FineID { get; set; }
        public int BookIssuanceID { get; set; }
        public int FineAmount { get; set; }
        public string FineArticle { get; set; }
    }
}