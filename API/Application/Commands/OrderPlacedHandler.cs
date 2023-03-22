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
            var order = _orderRepository.GetFlightRateById(request.Id);

            if (order == null)
                throw new KeyNotFoundException($"Unable to modify order because an entry with Id: {request.Id} could not be found");

            if (order.Available < request.Quantity)
                throw new ArgumentOutOfRangeException($"Unable to place order as the requested quantity ({request.Quantity}) is greater than the in stock quantity ({order.Available})");

            order.Available -= request.Quantity;

            await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            Console.WriteLine($"Order has been confirmed Id: {order.FlightId}, Name: {order.Name}");

            return order;




        }
    }
}
