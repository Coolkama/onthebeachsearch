using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> LocalAirports { get; set; } // List of airport codes near the hotel
        public int Nights { get; set; }

        // Constructor
        public Hotel(int id, string name, DateTime arrivalDate, decimal pricePerNight, List<string> localAirports, int nights)
        {
            Id = id;
            Name = name;
            ArrivalDate = arrivalDate;
            PricePerNight = pricePerNight;
            LocalAirports = localAirports;
            Nights = nights;
        }
    }


}
