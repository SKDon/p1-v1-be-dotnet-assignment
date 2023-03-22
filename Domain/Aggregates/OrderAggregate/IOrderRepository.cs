using Domain.Aggregates.FlightAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {

        Flight GetAsync(Guid flightId);
        Guid Add(Order order);
        FlightRate GetOrderById(Guid flightId, string name);
    }
}
