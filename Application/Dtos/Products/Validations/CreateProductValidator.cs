using Application.Contracts.Persistence.Products;
using Common.Enums;
using FluentValidation;

namespace Application.Dtos.Products.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            Include(new IBaseProdoctValidator() { });
            RuleFor(x => x.ProduceDate)
              .MustAsync(async (model, produceDate, cancellation) =>
              {
                  return await ExsistEmailAndDate(model.ManufactureEmail, produceDate.Value) == false;
              }).WithMessage(ResultStatusCodeEnum.DuplicateProduct.ToString());
        }
        protected async Task<bool> ExsistEmailAndDate(string manufaceEmail, DateTime produceDate)
        {
            var result = await _productRepository.IsExistValueAsync(x => x.ManufactureEmail.Equals(manufaceEmail) && x.ProduceDate.Date == produceDate.Date);
            return result;
        }
    }
}
