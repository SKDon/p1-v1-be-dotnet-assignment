using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.ApiResponses;
using API.Application.Queries.GetAllFlight;
using API.Application.Queries.GetFlightById;
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

    public FlightsController(ILogger<FlightsController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFlights()
    {
        var query = new GetAllFlightsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{flightId}")]
    public async Task<IActionResult> GetFlight(Guid flightId)
    {
        var query = new GetFlightByIdQuery(flightId);
        var result = await _mediator.Send(query);
        return result != null ? (IActionResult)Ok(result) : NotFound();
    }


}
