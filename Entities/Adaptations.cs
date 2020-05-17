namespace Entities
{
    public class Adaptations
    {
        public Adaptations(){}

        public Adaptations(int idAdaptation, int idBook, string typeAdaptation, int yearAdaptation, string countryAdaptation)
        {
            AdaptationID = idAdaptation;
            BookID = idBook;
            AdaptationType = typeAdaptation;
            AdaptationYear = yearAdaptation;
            AdaptationCountry = countryAdaptation;
        }

        public int AdaptationID { get; set; }
        public int BookID { get; set; }
        public string AdaptationType { get; set; }
        public int AdaptationYear { get; set; }
        public string AdaptationCountry { get; set; }
    }
}