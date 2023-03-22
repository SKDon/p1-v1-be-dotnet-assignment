using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {

        public Guid FlightRateId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public DateTimeOffset? OrderConfirmedDate { get; set; }
        public bool isConfirmed { get; set; }

        public Order()
        {
        }

        public Order(Guid flightRateId, string name, int quantity, decimal price, DateTimeOffset orderDate, DateTimeOffset? orderConfirmedDate, bool isConfirmed)
        {
            FlightRateId = flightRateId;
            Name = name;
            Quantity = quantity;
            Price = price;
            OrderDate = orderDate;
            OrderConfirmedDate = orderConfirmedDate;
            this.isConfirmed = isConfirmed;
        }
    }
}
