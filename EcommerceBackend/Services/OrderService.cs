using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceBackend.DTOs;
using EcommerceBackend.Interfaces;
using EcommerceBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly PaymentHelper _payment;

        public OrderService(ApplicationDbContext context, IMapper mapper, PaymentHelper payment)
        {
            _context = context;
            _mapper = mapper;
            _payment = payment;
        }

        public async Task<IEnumerable<OrderDto>> GetUserOrdersAsync(Guid userId)
        {
            var orders = await _context.Orders.Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .ToListAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto?> PlaceOrderAsync(Guid userId)
        {
            var cartItems = await _context.Products.Take(0).ToListAsync(); // placeholder for cart
            if (!cartItems.Any()) return null;

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Status = "Pending",
                Items = cartItems.Select(c => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = c.Id,
                    ProductName = c.Name,
                    Quantity = 1,
                    UnitPrice = c.Price
                }).ToList()
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var paymentResult = _payment.SimulatePayment();
            order.Paid = paymentResult;
            order.Status = paymentResult ? "Processing" : "Cancelled";
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> UpdateOrderStatusAsync(Guid orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return false;
            order.Status = status;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
