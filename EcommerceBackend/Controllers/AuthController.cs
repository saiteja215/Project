using System.Threading.Tasks;
using EcommerceBackend.DTOs;
using EcommerceBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var token = await _service.RegisterAsync(dto);
            if (token == null) return BadRequest("User exists");
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _service.LoginAsync(dto);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }
    }
}
