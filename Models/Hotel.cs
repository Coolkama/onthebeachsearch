using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Models
{
    public class Hotel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonProperty("price_per_night")]
        public decimal PricePerNight { get; set; }
        [JsonProperty("local_airports")]
        public List<string> LocalAirports { get; set; } // List of airport codes near the hotel
        [JsonProperty("nights")]
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
