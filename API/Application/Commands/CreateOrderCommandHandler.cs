using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.Add(new Order(request.Id, request.Name, request.Quantity));
            return Task.FromResult(order);
        }

    }
}
