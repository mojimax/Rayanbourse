using Application.Contracts.Services.Auth;
using Application.Dtos.Auth;
using Application.Features.Auth.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Handlers.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult<RegistrationResponseDto>>
    {
        private readonly IAuthService _authService;
        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<OperationResult<RegistrationResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _authService.Register(request.RegisterationRequest, cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
