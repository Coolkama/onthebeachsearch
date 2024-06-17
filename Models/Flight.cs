using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Models
{
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("airline")]
        public string Airline { get; set; }
        [JsonProperty("from")]
        public string From { get; set; } // Airport code where the flight departs
        [JsonProperty("to")]
        public string To { get; set; } // Airport code where the flight arrives
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }

        // Constructor
        public Flight(int id, string airline, string from, string to, decimal price, DateTime departureDate)
        {
            Id = id;
            Airline = airline;
            From = from;
            To = to;
            Price = price;
            DepartureDate = departureDate;
        }
    }
}
