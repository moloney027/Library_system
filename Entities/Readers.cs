namespace Entities
{
    public class Readers
    {
        public Readers(){}

        public Readers(int idReader, string fullName, int ageReader, string addressReader)
        {
            LibraryCardReader = idReader;
            ReaderFullName = fullName;
            ReaderAge = ageReader;
            ReaderAddress = addressReader;
        }

        public int LibraryCardReader { get; set; }
        public string ReaderFullName { get; set; }
        public int ReaderAge { get; set; }
        public string ReaderAddress { get; set; }
    }
}