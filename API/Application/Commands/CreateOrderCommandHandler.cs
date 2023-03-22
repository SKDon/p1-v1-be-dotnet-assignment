using API.Application.ViewModels;
using API.Mapping;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
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
            var entity = request.ToCreateEntity();
            var order = _orderRepository.Add(entity);
            return Task.FromResult(order);
        }

    }
}
