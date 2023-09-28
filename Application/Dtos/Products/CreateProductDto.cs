namespace Application.Dtos.Products
{
    public class CreateProductDto : IBaseProdoctDto
    {
        public CreateProductDto()
        {
            ProduceDate = DateTime.Now;
        }
        public string Name { get; set; } = string.Empty;
        public string ManufacturePhone { get; set; } = string.Empty;
        public string ManufactureEmail { get; set; } = string.Empty;
        public DateTime? ProduceDate { get; set; }
    }
}
