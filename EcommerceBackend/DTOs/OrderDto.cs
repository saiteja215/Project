using System;
using System.Collections.Generic;

namespace EcommerceBackend.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "Pending";
        public bool Paid { get; set; }
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
