using API.Application.Commands;
using AutoMapper;
using Domain.Aggregates.OrderAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceOrderController : ControllerBase
    {
        private readonly ILogger<PlaceOrderController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PlaceOrderController(ILogger<PlaceOrderController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderPlacedCommand command)
        {
            var result = await _mediator.Send(command);

            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
