using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
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

        public Task<FlightDto> GetAsync(Guid flightId)
        {

            var result = (from ep in _context.Flights
                          join e in _context.Airports on ep.OriginAirportId equals e.Id
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where ep.Id.Equals(flightId) && t.Price != null
                          select new FlightDto()
                          {
                              Id = ep.Id,
                              DepartureAirportCode = _context.Airports.Single(e => e.Id == ep.DestinationAirportId).Code,
                              ArrivalAirportCode = _context.Airports.Single(e => e.Id == ep.OriginAirportId).Code,
                              Departure = ep.Departure,
                              Arrival = ep.Arrival,
                              PriceFrom = t.Price.Value,
                              Name = t.Name
                          }).OrderBy(a => a.PriceFrom).FirstOrDefault();

            return Task.FromResult(result);

        }

        public async Task<List<Flight>> GetAllAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task<List<FlightDto>> GetAllFlightsAsync(string airportCode)
        {
            var availableFlights = await (from flight in _context.Flights
                                          join des in _context.Airports on flight.DestinationAirportId equals des.Id
                                          join or in _context.Airports on flight.OriginAirportId equals or.Id
                                          join t in _context.FlightRates on flight.Id equals t.FlightId
                                          where des.Code == airportCode
                                          && flight.Rates.Any(rate => rate.Available > 0)
                                          select new FlightDto
                                          {
                                              Id = flight.Id,
                                              DepartureAirportCode = or.Code,
                                              ArrivalAirportCode = des.Code,
                                              Departure = flight.Departure,
                                              Arrival = flight.Arrival,
                                              PriceFrom = flight.Rates.Where(rate => rate.Available > 0)
                                                                             .Select(rate => rate.Price.Value)
                                                                             .Min(),
                                              Name = t.Name,
                                          }).ToListAsync();
            return availableFlights;
        }


        public Task<List<FlightDto>> All()
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
