using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries.GetFlightDetail;
using AutoMapper;
using Domain.Aggregates.FlightAggregate;
using Infrastructure.Repositores;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly ILogger<FlightsController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IFlightRepository _flightRepository;

    public FlightsController(ILogger<FlightsController> logger, IMediator mediator, IMapper mapper, IFlightRepository flightRepository)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _flightRepository = flightRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableFlights([FromBody] string flightNo)
    {
        if (string.IsNullOrEmpty(flightNo))
        {
            return Ok(_flightRepository.Search());

        } else
        {
            return Ok(await _mediator.Send(new GetFlightDetailQuery { code = flightNo }));
        }
        
    }
}
