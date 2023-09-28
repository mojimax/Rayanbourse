using Application.Dtos.Auth;
using Application.Response;
using MediatR;

namespace Application.Features.Auth.Requests.Commands
{
    public class RegisterUserCommand: IRequest<OperationResult<RegistrationResponseDto>>
    {
        public RegisterationRequestDto RegisterationRequest { get; set; }

    }
}
