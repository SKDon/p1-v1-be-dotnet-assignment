using API.Application.Commands;
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
    public class ConfirmOrderController : ControllerBase
    {
        private readonly ILogger<ConfirmOrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ConfirmOrderController(ILogger<ConfirmOrderController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOrder([FromBody] CreateOrderCommand command)
        {
            var model = await _mediator.Send(command);
            Console.WriteLine($"Your Order has been Confirm Flight No: {model.FlightId} Class: {model.Name} Departure Airport Code {model.DepartureAirportCode}");
            return Ok(model);
        }
    }
}
