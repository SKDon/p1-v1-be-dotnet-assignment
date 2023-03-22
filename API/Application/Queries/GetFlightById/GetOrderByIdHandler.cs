using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Application.Queries.GetFlightById
{
    public class GetOrderByIdHandler : IRequestHandler<GetFlightByIdQuery, List<FlightViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public GetOrderByIdHandler(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<List<FlightViewModel>> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _flightRepository.GetAllFlightsAsync(request.Code);

            return _mapper.Map<List<FlightViewModel>>(entities);
        }
    }
}
