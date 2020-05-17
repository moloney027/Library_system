namespace Entities
{
    public class Storage
    {
        public Storage(){}

        public Storage(int idStorage, int rackStorage, int shelfStorage)
        {
            StorageID = idStorage;
            StorageRack = rackStorage;
            StorageShelf = shelfStorage;
        }

        public int StorageID { get; set; }
        public int StorageRack { get; set; }
        public int StorageShelf { get; set; }
    }
}