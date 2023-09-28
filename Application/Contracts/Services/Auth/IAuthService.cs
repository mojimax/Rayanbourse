using Application.Dtos.Auth;
using Application.Response;

namespace Application.Contracts.Services.Auth
{
    public interface IAuthService
    {
        Task<OperationResult<LoginResponseDto>> Login(LoginRequestDto request, CancellationToken cancellationToken = (default));
        Task<OperationResult<RegistrationResponseDto>> Register(RegisterationRequestDto request, CancellationToken cancellationToken = (default));
    }
}
