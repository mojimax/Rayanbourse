using Application.Contracts.Services.Users;
using Common.Enums;
using FluentValidation;

namespace Application.Dtos.Auth.Validations
{
    public class RegisterationRequestValidator : AbstractValidator<RegisterationRequestDto>
    {
        IUserSerive _userSerive;
        public RegisterationRequestValidator(IUserSerive userService)
        {
            _userSerive = userService;
            CascadeMode = CascadeMode.Stop;
            Include(new IBaseAuthDtoValidator() { });
            RuleFor(x => x.Email)
                  .MustAsync(async (email, cancellation) =>
                  {
                      return await ExsistEmail(email) == false;
                  }).WithMessage(ResultStatusCodeEnum.UserNameExsist.ToString());
        }
        protected async Task<bool> ExsistEmail(string userName)
        {
            var result = await _userSerive.ExsistEmail(userName);
            return result.Data;
        }
    }
}
