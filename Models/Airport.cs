namespace OnTheBeachSearch.Models
{
    // will need to have validation on this with a database lookup.
    public class Airport
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        // Constructor
        public Airport(string code, string name, string city)
        {
            Code = code;
            Name = name;
            City = city;
        }
    }
}