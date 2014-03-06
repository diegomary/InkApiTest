using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InkAPITest.Models
{
    public class FlightRequest
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}