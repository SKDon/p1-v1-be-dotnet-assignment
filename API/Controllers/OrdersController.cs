using API.Application.Commands;
using API.Application.Queries.GetFlight;
using API.Application.Queries.GetFlightById;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository orderRepository, ILogger<OrdersController> logger, IMediator mediator, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetOrder(Guid flightId)
        {
            var query = new GetFlightQuery(flightId);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrder), new { Id = id }, id);
        }
    }
}
