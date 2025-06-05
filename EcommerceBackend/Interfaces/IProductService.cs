using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcommerceBackend.DTOs;

namespace EcommerceBackend.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(Guid id);
        Task<ProductDto> AddAsync(AddProductDto dto);
        Task<ProductDto?> UpdateAsync(Guid id, AddProductDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
