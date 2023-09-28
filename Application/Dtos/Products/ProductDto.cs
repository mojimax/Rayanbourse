using Application.Dtos.Base;

namespace Application.Dtos.Products
{
    public class ProductDto : IBaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProduceDate { get; set; } = string.Empty;
        public string ManufacturePhone { get; set; } = string.Empty;
        public string ManufactureEmail { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
