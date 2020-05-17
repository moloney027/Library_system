namespace Entities
{
    public class PublishingHouse
    {
        public PublishingHouse(){}

        public PublishingHouse(int idPH, string titePH, int datePH, int idCity)
        {
            PublishingHouseID = idPH;
            PublishingHouseTitle = titePH;
            DateOfEstablishment = datePH;
            CityID = idCity;
        }

        public int PublishingHouseID { get; set; }
        public string PublishingHouseTitle { get; set; }
        public int DateOfEstablishment { get; set; }
        public int CityID { get; set; }
    }
}