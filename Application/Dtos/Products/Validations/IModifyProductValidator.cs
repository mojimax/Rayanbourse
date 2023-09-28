using Application.Contracts.Persistence.Products;
using Common.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Dtos.Products.Validations
{
    public class IModifyProductValidator : AbstractValidator<IModifyProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IModifyProductValidator(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _httpContextAccessor = httpContextAccessor;
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id)
                .MustAsync(async (Id, cancellation) =>
                {
                    return await CheckId(Id);
                }).WithMessage(ResultStatusCodeEnum.ProductIdInvalid.ToString());
            RuleFor(x => x.CurrentUserId)
                .MustAsync(async (CurrentUserId, cancellation) =>
                {
                    return await CheckUserId(CurrentUserId);
                }).WithMessage(ResultStatusCodeEnum.UserNotAccess.ToString());
        }
        protected async Task<bool> CheckUserId(string CurrentUserId)
        {
            var userId = CurrentUserId ?? _httpContextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Sid);
            if (!string.IsNullOrEmpty(userId))
            {
                return await _productRepository.IsExistValueAsync(x => x.CreateById.Equals(userId));
            }
            return false;
        }
        protected async Task<bool> CheckId(Guid id)
        {
            return await _productRepository.IsExistValueAsync(x => x.Id == id);
        }
    }
}
