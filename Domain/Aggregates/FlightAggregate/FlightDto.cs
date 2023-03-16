using System;


namespace Domain.Aggregates.FlightAggregate
{
    public  class FlightDto
    {
        public Guid Id { get; set; }
        public string DepartureAirportCode { get; set;}
        public string ArrivalAirportCode { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTimeOffset Arrival { get; set; }
        public decimal PriceFrom { get; set; }
        public string Name { get; set; }
    }
}
