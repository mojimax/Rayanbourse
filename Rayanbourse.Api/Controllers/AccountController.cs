using Application.Contracts.Services.Auth;
using Application.Dtos.Auth;
using Application.Features.Auth.Requests.Commands;
using Application.Response;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rayanbourse.Api.Controllers.Base;

namespace Rayanbourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        public async Task<OperationResult<LoginResponseDto>> Login(LoginRequestDto login, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new LoginUserCommand() { LoginRequest = login }, cancellationToken);
        }
        [HttpPost("Register")]
        public async Task<OperationResult<RegistrationResponseDto>> Register(RegisterationRequestDto registeration, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new RegisterUserCommand() { RegisterationRequest = registeration }, cancellationToken);

        }
    }
}
