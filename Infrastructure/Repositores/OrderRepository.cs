using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public Task<List<OrderDetailsDto>> GetOrderById(Guid flighttId)
        {
            var result = (from ep in _context.Flights
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where ep.Id.Equals(flighttId)
                          select new OrderDetailsDto
                          {
                              Name = t.Name,
                              Price = t.Price.Value,
                              Available = t.Available,
                              FlightId = ep.Id
                          }).ToList();

            return Task.FromResult(result);
        }

        public OrderDto Add(Order order)
        {

            var result = _context.FlightRates.SingleOrDefault(b => b.FlightId == order.Id && b.Name == order.Type);

            if (result != null)
            {
                result.Available = result.Available - order.Quantity;
            }

            var model =  _context.FlightRates.Update(result).Entity;

            _context.SaveChanges();

            var entity = (from ep in _context.Flights
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where t.Id.Equals(model.Id)
                          select new OrderDto
                          {
                              Name = t.Name,
                              Price = t.Price.Value,
                              FlightId = t.FlightId,
                              DepartureAirportCode = _context.Airports.Single(e => e.Id == ep.DestinationAirportId).Code,
                              ArrivalAirportCode = _context.Airports.Single(e => e.Id == ep.OriginAirportId).Code,
                              Departure = ep.Departure
                          }).SingleOrDefault();

            return entity;
        }
    }
}
