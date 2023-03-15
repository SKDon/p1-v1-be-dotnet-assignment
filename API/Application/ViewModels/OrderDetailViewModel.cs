using System;

namespace API.Application.ViewModels
{
    public class OrderDetailViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Available { get; set; }
        public Guid FlightId { get; set; }
    }
}
