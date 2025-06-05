using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            return Ok(await _service.GetUserOrdersAsync(userId));
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var order = await _service.PlaceOrderAsync(userId);
            if (order == null) return BadRequest("Cart empty");
            return Ok(order);
        }
    }
}
