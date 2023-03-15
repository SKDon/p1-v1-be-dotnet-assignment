using API.Application.ViewModels;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Queries.GetOrderDetail
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<OrderDetailViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailViewModel>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var model = await _orderRepository.GetOrderById(request.Id);
            return _mapper.Map<List<OrderDetailViewModel>>(model);

        }
    }
}
