using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.OrderAggregate
{
    public class OrderDetailsDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Available { get; set; }
        public Guid FlightId { get; set; }
    }
}
