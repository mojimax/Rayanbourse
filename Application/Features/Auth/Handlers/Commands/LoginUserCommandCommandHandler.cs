using Application.Contracts.Services.Auth;
using Application.Dtos.Auth;
using Application.Features.Auth.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Handlers.Commands
{
    public class LoginUserCommandCommandHandler : IRequestHandler<LoginUserCommand, OperationResult<LoginResponseDto>>
    {
        private readonly IAuthService _authService;
        public LoginUserCommandCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<OperationResult<LoginResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _authService.Login(request.LoginRequest);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
