namespace Entities
{
    public class Fine
    {
        public Fine(){}

        public Fine(int idFine, int idBI, byte amountFine)
        {
            FineID = idFine;
            BookIssuanceID = idBI;
            FineAmount = amountFine;
        }

        public int FineID { get; set; }
        public int BookIssuanceID { get; set; }
        public byte FineAmount { get; set; }
    }
}