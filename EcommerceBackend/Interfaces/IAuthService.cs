using System.Threading.Tasks;
using EcommerceBackend.DTOs;

namespace EcommerceBackend.Interfaces
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
