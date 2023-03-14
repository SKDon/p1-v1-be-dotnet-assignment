using Domain.Common;
using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }
        public Price Price { get; set; }
        public Guid FlightId { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset Departure { get; set; }
    }

}
