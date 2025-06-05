using System;
using System.Threading.Tasks;
using EcommerceBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.AdminControllers
{
    [ApiController]
    [Route("api/v1/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public AdminOrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] string status)
        {
            var ok = await _service.UpdateOrderStatusAsync(id, status);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
