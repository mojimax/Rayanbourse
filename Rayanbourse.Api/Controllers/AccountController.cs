using Application.Contracts.Services.Auth;
using Application.Dtos.Auth;
using Application.Response;
using Microsoft.AspNetCore.Mvc;
using Rayanbourse.Api.Controllers.Base;

namespace Rayanbourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<OperationResult<LoginResponseDto>> Login(LoginRequestDto login, CancellationToken cancellationToken)
        {
            return await _authService.Login(login, cancellationToken);

        }
        [HttpPost("Register")]
        public async Task<OperationResult<RegistrationResponseDto>> Register(RegisterationRequestDto request, CancellationToken cancellationToken)
        {
            return await _authService.Register(request, cancellationToken);
        }
    }
}
