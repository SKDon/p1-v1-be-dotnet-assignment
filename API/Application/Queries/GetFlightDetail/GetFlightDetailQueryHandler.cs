using API.ApiResponses;
using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetFlightDetail
{
    public class GetFlightDetailQueryHandler : IRequestHandler<GetFlightDetailQuery, FlightViewModel>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightDetailQueryHandler(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<FlightViewModel> Handle(GetFlightDetailQuery request, CancellationToken cancellationToken)
        {
            var model = await _flightRepository.Search(request.code);
            return _mapper.Map<FlightViewModel>(model);
        }


    }
}
