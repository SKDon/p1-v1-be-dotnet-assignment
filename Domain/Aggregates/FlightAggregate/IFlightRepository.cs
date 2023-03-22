using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository
    {
        Flight Add(Flight flight);
        void Update(Flight flight);
        Task<FlightDto> GetAsync(Guid flightId);
        Task<List<FlightDto>> GetAllFlightsAsync(string airportCode);
        Task<List<FlightDto>> All();
        Task<List<Flight>> GetAllAsync();
    }
}