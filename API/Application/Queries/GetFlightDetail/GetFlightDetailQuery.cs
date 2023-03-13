using API.ApiResponses;
using API.Application.ViewModels;
using MediatR;

namespace API.Application.Queries.GetFlightDetail
{
    public class GetFlightDetailQuery : IRequest<FlightViewModel>
    {
        public string code { get; set; }
    }
}
