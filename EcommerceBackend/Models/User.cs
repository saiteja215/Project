using System;
using System.Collections.Generic;

namespace EcommerceBackend.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = "User";
        public bool IsBlocked { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
