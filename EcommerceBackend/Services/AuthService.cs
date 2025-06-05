using System;
using System.Linq;
using System.Threading.Tasks;
using EcommerceBackend.DTOs;
using EcommerceBackend.Interfaces;
using EcommerceBackend.Models;
using EcommerceBackend.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwt;

        public AuthService(ApplicationDbContext context, JwtHelper jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<string?> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _jwt.GenerateToken(user);
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;
            return _jwt.GenerateToken(user);
        }
    }
}
