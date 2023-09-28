using Application.Contracts.Persistence.Products;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos.Products.Validations
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateProductValidator(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            Include(new IModifyProductValidator(_productRepository, _httpContextAccessor) { });
            Include(new IBaseProdoctValidator() { });

        }
    }
}
