using API.Application.Queries.GetFlightById;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetFlight
{
    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, FlightViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public GetFlightQueryHandler(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<FlightViewModel> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var entities = await _flightRepository.GetAsync(request.Id);

            return _mapper.Map<FlightViewModel>(entities);
        }
    }
}
