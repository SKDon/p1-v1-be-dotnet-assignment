using API.ApiResponses;
using API.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace API.Application.Queries.GetAllFlight
{
    public class GetAllFlightsQuery : IRequest<List<FlightViewModel>>
    {
    }
}
