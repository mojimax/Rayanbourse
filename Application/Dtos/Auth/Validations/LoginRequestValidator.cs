using Application.Contracts.Services.Users;
using Common.Enums;
using FluentValidation;

namespace Application.Dtos.Auth.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
    {
        IUserSerive _userSerive;
        public LoginRequestValidator(IUserSerive userSerive)
        {
            _userSerive = userSerive;
            Include(new IBaseAuthDtoValidator());
            RuleFor(x => x.Email)
                .MustAsync(async (email, cancellation) =>
                {
                    return await ExsistUser(email);
                }).WithMessage(ResultStatusCodeEnum.UserNotExsist.ToString());
        }
        protected async Task<bool> ExsistUser(string email)
        {
            var result = await _userSerive.ExsistEmail(email);
            return result.Data;
        }
    }
}
