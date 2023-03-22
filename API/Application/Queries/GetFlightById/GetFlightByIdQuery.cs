using API.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Queries.GetFlightById
{
    public class GetFlightByIdQuery : IRequest<List<FlightViewModel>>
    {
        public string Code { get; set; }

        public GetFlightByIdQuery(string code)
        {
            Code = code;
        }
    }
}
