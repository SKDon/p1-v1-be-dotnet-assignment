using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<OrderDetailsDto>> GetOrderById(Guid flightId);
        OrderDto Add(Order order);
    }
}
