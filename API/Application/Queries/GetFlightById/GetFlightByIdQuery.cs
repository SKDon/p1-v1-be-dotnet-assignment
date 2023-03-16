using API.Application.ViewModels;
using MediatR;
using System;

namespace API.Application.Queries.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<FlightViewModel>
    {
        public Guid Id { get; set; }

        public GetFlightByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
