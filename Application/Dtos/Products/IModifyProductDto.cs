using Application.Dtos.Base;

namespace Application.Dtos.Products
{
    public interface IModifyProductDto : IBaseDto
    {
        public string? CurrentUserId { get; set; }

    }
}
