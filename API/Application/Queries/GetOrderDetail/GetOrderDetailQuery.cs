using API.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace API.Application.Queries.GetOrderDetail
{
    public class GetOrderDetailQuery : IRequest<List<OrderDetailViewModel>>
    {
        public Guid Id { get; set; }
    }
}
