namespace EcommerceBackend.DTOs
{
    public class AddProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
