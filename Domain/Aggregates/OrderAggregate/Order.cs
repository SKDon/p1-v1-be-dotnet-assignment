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
        //public Guid Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

        public Order()
        {
        }

        public Order(Guid id, string type, int quantity)
        {
            Id = id;
            Type = type;
            Quantity = quantity;
        }
    }
}
