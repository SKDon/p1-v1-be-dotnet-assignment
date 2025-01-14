﻿using API.Application.ViewModels;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public CreateOrderCommand(Guid id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
