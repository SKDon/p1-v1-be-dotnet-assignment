using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Commands
{
    public class OrderPlacedHandler : IRequestHandler<OrderPlacedCommand, FlightRate>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderPlacedHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<FlightRate> Handle(OrderPlacedCommand request, CancellationToken cancellationToken)
        {
            var entity= _orderRepository.GetFlightRateById(request.Id);
            var order = _orderRepository.GetOrderById(request.Id);

            if (entity== null)
                throw new KeyNotFoundException($"Unable to modify entitybecause an entry with Id: {order.Id} could not be found");

            if (entity.Available < order.Quantity)
                throw new ArgumentOutOfRangeException($"Unable to place entityas the requested quantity ({order.Quantity}) is greater than the in stock quantity ({entity.Available})");

            entity.Available -= order.Quantity;

            await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            Console.WriteLine($"entityhas been confirmed Id: {entity.FlightId}, Name: {entity.Name}");

            return entity;




        }
    }
}
