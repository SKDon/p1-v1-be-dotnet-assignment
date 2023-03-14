using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Add(new Order(request.Id, request.Type, request.Quantity));

            await _orderRepository.UnitOfWork.SaveEntitiesAsync();

            return _mapper.Map<OrderViewModel>(order);

        }
    }
}
