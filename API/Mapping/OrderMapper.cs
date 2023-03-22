using API.Application.Commands;
using Domain.Aggregates.OrderAggregate;
using System;

namespace API.Mapping
{
    public static class OrderMapper
    {
        public static Order ToCreateEntity(this CreateOrderCommand command)
        {
            var result = new Order
            {
                FlightRateId = command.Id,
                Name = command.Name,
                Quantity = command.Quantity,
                Price = 0,
                OrderDate = DateTimeOffset.Now,
                OrderConfirmedDate = DateTimeOffset.Now
            };

            return result;
        }
    }
}
