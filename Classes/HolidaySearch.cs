using Newtonsoft.Json;
using OnTheBeachSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Classes
{
    public class HolidaySearch
    {
        public List<Flight> Flights { get; set; }
        public List<Hotel> Hotels { get; set; }

        private string[] LondonAirports = ["LHR", "LGW", "LCY", "LTN", "STN"];

        public HolidaySearch(string flightsJSON, string hotelsJSON)
        {
            Flights = LoadFlights(flightsJSON);
            Hotels = LoadHotels(hotelsJSON);
        }

        private List<Flight> LoadFlights(string json)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                };

                return JsonConvert.DeserializeObject<List<Flight>>(json, settings) ?? new List<Flight>();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading flights: " + ex.Message);
                return new List<Flight>();
            }
        }

        private List<Hotel> LoadHotels(string json)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                };

                return JsonConvert.DeserializeObject<List<Hotel>>(json,settings) ?? new List<Hotel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading hotels: " + ex.Message);
                return new List<Hotel>();
            }
        }

        public List<Package> Search(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            var matchingFlights = Flights.Where(f => (f.From == departingFrom || departingFrom == "ANY" || (departingFrom == "LON" && LondonAirports.Contains(f.From))) &&
                                                             f.To == travelingTo &&
                                                             f.DepartureDate.Date == departureDate.Date)
                                         .ToList();

            var matchingHotels = Hotels.Where(h => h.LocalAirports.Contains(travelingTo) &&
                                                   h.ArrivalDate == departureDate.Date && h.Nights == duration)
                                       .ToList();

            var matchingPackages = (from flight in matchingFlights
                                    from hotel in matchingHotels
                                    where flight.DepartureDate.Date == hotel.ArrivalDate.Date &&
                                          hotel.Nights == duration &&
                                          hotel.LocalAirports.Contains(flight.To)
                                    select new Package(flight, hotel))
                                   .OrderBy(p => p.TotalPrice)
                                   .ToList();

            return matchingPackages;
        }
    }
}
