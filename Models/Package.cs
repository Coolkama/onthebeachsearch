using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachSearch.Models
{
    public class Package
    {
        public Package(Flight flight, Hotel hotel)
        {
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            Hotel = hotel ?? throw new ArgumentNullException(nameof(hotel));
        }

        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice => (Hotel.PricePerNight * Hotel.Nights) + Flight.Price;
    }

}
