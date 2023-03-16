using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetAllFlight
{
    public class GetAllFlightHandler : IRequestHandler<GetAllFlightsQuery, List<FlightViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public GetAllFlightHandler(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightViewModel>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            var entities = await _flightRepository.All();

            return _mapper.Map<List<FlightViewModel>>(entities);
        }
    }
}
