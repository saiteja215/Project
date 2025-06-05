using AutoMapper;
using EcommerceBackend.DTOs;
using EcommerceBackend.Models;

namespace EcommerceBackend.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<AddProductDto, Product>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
