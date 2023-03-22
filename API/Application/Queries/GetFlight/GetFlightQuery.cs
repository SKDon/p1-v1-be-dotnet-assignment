using API.Application.ViewModels;
using MediatR;
using System;

namespace API.Application.Queries.GetFlight
{
    public class GetFlightQuery : IRequest<FlightViewModel>
    {
        public Guid Id { get; set; }

        public GetFlightQuery(Guid id)
        {
            Id = id;
        }
    }
}
