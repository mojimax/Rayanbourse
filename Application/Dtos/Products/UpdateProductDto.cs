namespace Application.Dtos.Products
{
    public class UpdateProductDto : IBaseProdoctDto, IModifyProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ManufacturePhone { get; set; } = string.Empty;
        public string ManufactureEmail { get; set; } = string.Empty;
        public DateTime? ProduceDate { get; set; }
        public bool IsAvailable { get; set; }
        public string? CurrentUserId { get; set; }
    }
}
