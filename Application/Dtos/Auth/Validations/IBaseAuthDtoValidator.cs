using Common.Enums;
using FluentValidation;

namespace Application.Dtos.Auth.Validations
{
    public class IBaseAuthDtoValidator : AbstractValidator<IBaseAuthDto>
    {
        public IBaseAuthDtoValidator()
        {
            RuleFor(x => x.Email)
             .NotEmpty().WithMessage(ResultStatusCodeEnum.EmailInvalid.ToString())
             .EmailAddress().WithMessage(ResultStatusCodeEnum.EmailInvalid.ToString());
            RuleFor(x => x.Password).NotEmpty().WithMessage(ResultStatusCodeEnum.PasswordNotNull.ToString())
                .MinimumLength(8)
                .WithMessage(ResultStatusCodeEnum.PasswordInvalid.ToString());
        }
    }
}
