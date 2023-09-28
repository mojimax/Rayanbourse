using Common.Enums;
using FluentValidation;

namespace Application.Dtos.Products.Validations
{
    public class IBaseProdoctValidator : AbstractValidator<IBaseProdoctDto>
    {
        public IBaseProdoctValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage(ResultStatusCodeEnum.NameRequired.ToString());
            RuleFor(x => x.ManufacturePhone)
             .NotEmpty().WithMessage(ResultStatusCodeEnum.PhoneNumberInvalid.ToString())
             .Must(x => x.Length == 11).WithMessage(ResultStatusCodeEnum.PhoneNumberInvalid.ToString());
            RuleFor(x => x.ManufactureEmail)
                .NotEmpty().WithMessage(ResultStatusCodeEnum.EmailInvalid.ToString())
                .EmailAddress().WithMessage(ResultStatusCodeEnum.EmailInvalid.ToString())
                .WithMessage(ResultStatusCodeEnum.EmailInvalid.ToString());

        }


    }
}
