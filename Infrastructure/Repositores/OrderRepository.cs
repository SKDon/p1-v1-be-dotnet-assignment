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

        public Flight GetAsync(Guid flightId)
        {
            return  _context.Flights.SingleOrDefault(o => o.Id == flightId);
        }


        public Guid Add(Order order)
        {
            var result = GetAsync(order.Id);

            var entity = _context.Flights.Update(result).Entity;

            _context.SaveChangesAsync();

            return entity.Id;

        }

        public FlightRate GetOrderById(Guid flightId)
        {
            return _context.FlightRates.SingleOrDefault(o => o.FlightId == flightId);

        }


    }
}
