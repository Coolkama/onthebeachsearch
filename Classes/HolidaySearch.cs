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

        public HolidaySearch(string flights, string hotels)
        {
            Flights = LoadFlights(flights);
            Hotels = LoadHotels(hotels);
        }

        private List<Flight> LoadFlights(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Flight>>(json) ?? new List<Flight>();
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
                return JsonConvert.DeserializeObject<List<Hotel>>(json) ?? new List<Hotel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading hotels: " + ex.Message);
                return new List<Hotel>();
            }
        }

        public Package Search(string departingFrom, string travelingTo, DateTime departureDate, int duration)
        {
            var matchingFlights = Flights.Where(f => (f.From == departingFrom || departingFrom == "Any Airport") &&
                                                             f.To == travelingTo &&
                                                             f.DepartureDate == departureDate);

            var matchingHotels = Hotels.Where(h => h.LocalAirports.Contains(travelingTo) &&
                                                   h.ArrivalDate == departureDate && h.Nights == duration);
            var bestPackage = (from flight in matchingFlights
                               from hotel in matchingHotels
                               select new Package(flight, hotel)
                                    ).ToList().OrderBy(p => p.TotalPrice).ToList().FirstOrDefault();

            return bestPackage ?? new Package(new Flight(0, "", "", "", decimal.Zero, DateTime.Now), new Hotel(0, "", DateTime.Now, 0, [], 0));
        }
    }
}
