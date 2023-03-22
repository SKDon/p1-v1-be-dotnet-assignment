using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
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

        public void Update(Order order)
        {
            _context.Orders.Update(order);

            _context.SaveChangesAsync();
        }

        public FlightRate GetAsync(Order order)
        {
            return  _context.FlightRates.SingleOrDefault(o => o.FlightId == order.FlightRateId && o.Name == order.Name);
        }

        public Order GetOrderById(Guid orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == orderId);
        }


        public Guid Add(Order order)
        {
            var result = GetAsync(order);

            if (result == null)
            {
                throw new Exception("FlightRateId is incorrect..!");
            }
            else
            {
                order.OrderConfirmedDate = DateTime.UtcNow;
                order.isConfirmed = true;
                order.Price = result.Price.Value * order.Quantity;
            }

            var entity = _context.Orders.Add(order).Entity;

            _context.SaveChangesAsync();

            return entity.Id;

        }

        public FlightRate GetFlightRateById(Guid flightId)
        {
            var order = GetOrderById(flightId);

            return _context.FlightRates.SingleOrDefault(o => o.FlightId == order.FlightRateId && o.Name == order.Name);

        }


    }
}
