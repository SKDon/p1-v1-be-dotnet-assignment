using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetFlightById
{
    public class GetOrderByIdHandler : IRequestHandler<GetFlightByIdQuery, FlightViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public GetOrderByIdHandler(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }

        public async Task<FlightViewModel> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _flightRepository.GetAsync(request.Id);

            return _mapper.Map<FlightViewModel>(entities);
        }
    }
}
