using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string From { get; set; } // Airport code where the flight departs
        public string To { get; set; } // Airport code where the flight arrives
        public decimal Price { get; set; }
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
