using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceBackend.DTOs;

namespace EcommerceBackend.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetUserOrdersAsync(Guid userId);
        Task<OrderDto?> PlaceOrderAsync(Guid userId);
        Task<bool> UpdateOrderStatusAsync(Guid orderId, string status);
    }
}
