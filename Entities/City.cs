namespace Entities
{
    public class City
    {
        public City(){}

        public City(int idCity, string cityTitle)
        {
            CityID = idCity;
            CityTitle = cityTitle;
        }

        public int CityID { get; set; }
        public string CityTitle { get; set; }
    }
}