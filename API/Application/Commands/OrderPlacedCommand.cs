using API.Application.ViewModels;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System;

namespace API.Application.Commands
{
    public class OrderPlacedCommand : IRequest<FlightRate>
    {
        public Guid Id { get; set; }

        public OrderPlacedCommand(Guid id)
        {
            Id = id;
        }
    }
}
