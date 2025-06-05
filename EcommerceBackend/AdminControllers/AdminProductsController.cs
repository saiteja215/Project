using System;
using System.Threading.Tasks;
using EcommerceBackend.DTOs;
using EcommerceBackend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.AdminControllers
{
    [ApiController]
    [Route("api/v1/admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public AdminProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDto dto)
        {
            var product = await _service.AddAsync(dto);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AddProductDto dto)
        {
            var product = await _service.UpdateAsync(id, dto);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
