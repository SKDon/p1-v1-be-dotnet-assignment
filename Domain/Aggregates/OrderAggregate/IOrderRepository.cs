﻿using Domain.SeedWork;

namespace Domain.Aggregates.OrderAggregate
{
    public interface IOrderRepository : IRepository<Order>
    {
        OrderDto Add(Order order);
    }
}
