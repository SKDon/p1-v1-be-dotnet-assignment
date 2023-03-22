using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        FlightRate GetAsync(Order order);
        Guid Add(Order order);
        FlightRate GetFlightRateById(Guid flightId);
        Order GetOrderById(Guid orderId);
        void Update(Order order);
    }
}
