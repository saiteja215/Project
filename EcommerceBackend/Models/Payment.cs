using System;

namespace EcommerceBackend.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public string Status { get; set; } = "Pending"; // Success, Failed
        public string TransactionId { get; set; } = string.Empty;
    }
}
