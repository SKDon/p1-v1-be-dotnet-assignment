using API.Application.Commands;
using API.Application.Queries.GetOrderDetail;
using API.Application.ViewModels;
using AutoMapper;
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
        private readonly ILogger<OrdersController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(ILogger<OrdersController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder([FromBody] Guid id)
        {
            return Ok(await _mediator.Send(new GetOrderDetailQuery { Id = id }));
            //var model = await _mediator.Send(command);
            //Console.WriteLine($"Your Order has been Confirm Flight No: {model.FlightId} Class: {model.Name} Departure Airport Code {model.DepartureAirportCode}");
            //return Ok(model);
        }
    }
}
