using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderViewModel>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public CreateOrderCommand(Guid id, string type, int quantity)
        {
            Id = id;
            Type = type;
            Quantity = quantity;
        }
    }
}
