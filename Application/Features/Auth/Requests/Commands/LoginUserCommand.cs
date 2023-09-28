using Application.Dtos.Auth;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Requests.Commands
{
    public class LoginUserCommand : IRequest<OperationResult<LoginResponseDto>>
    {
        public LoginRequestDto LoginRequest { get; set; }

    }
}
