﻿using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FlightsContext _context;

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public OrderRepository(FlightsContext context)
        {
            _context = context;
        }

        public OrderDto Add(Order order)
        {
            var result = (from ep in _context.Flights
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where t.FlightId.Equals(order.Id) && t.Name.Equals(order.Type)
                          select new FlightRate
                          { 
                              Name = t.Name,
                              Price = t.Price,
                              Available = t.Available - order.Quantity,
                              FlightId = t.FlightId
                          }).FirstOrDefault();

            var model = _context.FlightRates.Add(result).Entity;

            var entity = (from ep in _context.Flights
                          join t in _context.FlightRates on ep.Id equals t.FlightId
                          where t.FlightId.Equals(model.Id) 
                          select new OrderDto
                          {
                              Name = t.Name,
                              Price = t.Price,
                              FlightId = t.FlightId,
                              DepartureAirportCode = _context.Airports.Single(e => e.Id == ep.DestinationAirportId).Code,
                              ArrivalAirportCode = _context.Airports.Single(e => e.Id == ep.OriginAirportId).Code,
                              Departure = ep.Departure
                          }).FirstOrDefault();

            return entity; 
        }
    }
}