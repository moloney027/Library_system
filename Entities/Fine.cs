namespace Entities
{
    public class Fine
    {
        public Fine(){}

        public Fine(int idFine, int idBI, byte amountFine, string articleFine)
        {
            FineID = idFine;
            BookIssuanceID = idBI;
            FineAmount = amountFine;
            FineArticle = articleFine;
        }

        public int FineID { get; set; }
        public int BookIssuanceID { get; set; }
        public byte FineAmount { get; set; }
        public string FineArticle { get; set; }
    }
}