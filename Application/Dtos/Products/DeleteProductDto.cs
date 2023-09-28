namespace Application.Dtos.Products
{
    public class DeleteProductDto : IModifyProductDto
    {
        public string? CurrentUserId { get; set; }
        public Guid Id { get; set; }
    }
}
