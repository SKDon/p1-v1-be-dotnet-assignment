using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public FlightRepository(FlightsContext context)
        {
            _context = context;
        }

        public Flight Add(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }


        public Task<Flight> GetAsync(Guid flightId)
        {
            throw new NotImplementedException();
        }

        public Task<FlightDto> Search(string flightCode)
        {
            var result = (from ep in _context.Flights
                          join e in _context.Airports on ep.OriginAirportId equals e.Id
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where ep.DestinationAirportId.Equals(_context.Airports.Single(e => e.Code == flightCode).Id) && t.Price != null
                          select new FlightDto
                          {
                              Id = ep.Id,
                              DepartureAirportCode = _context.Airports.Single(e => e.Id == ep.DestinationAirportId).Code,
                              ArrivalAirportCode = _context.Airports.Single(e => e.Id == ep.OriginAirportId).Code,
                              Departure = ep.Departure,
                              Arrival = ep.Arrival,
                              PriceFrom = t.Price.Value
                          }).OrderBy(a => a.PriceFrom).FirstOrDefault();

            return Task.FromResult(result);
        }

        public Task<List<FlightDto>> Search()
        {
            var result = (from ep in _context.Flights
                          join e in _context.Airports on ep.OriginAirportId equals e.Id
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where t.Price != null
                          select new FlightDto
                          {
                              Id = ep.Id,
                              DepartureAirportCode = _context.Airports.Single(e => e.Id == ep.DestinationAirportId).Code,
                              ArrivalAirportCode = _context.Airports.Single(e => e.Id == ep.OriginAirportId).Code,
                              Departure = ep.Departure,
                              Arrival = ep.Arrival,
                              PriceFrom = t.Price.Value
                          }).ToList();


            return Task.FromResult(result);
        }
    }
}
