using Application.Contracts.Persistence.Products;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Products.Validations
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteProductValidator(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            Include(new IModifyProductValidator(_productRepository, _httpContextAccessor) { });
        }
    }
}
