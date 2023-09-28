using Application.Contracts.General;
using Application.Contracts.Services.Auth;
using Application.Dtos.Auth;
using Application.Response;
using AutoMapper;
using Common.Enums;
using Domain.Users;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettingsDto _jwtSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly IResponseHelperService _responseHelper;
        private readonly IValidator<RegisterationRequestDto> _validatorRegister;
        private readonly IValidator<LoginRequestDto> _validatorLogin;
        private readonly IMapper _mapper;
        public AuthService(UserManager<User> userManager,
            IOptions<JwtSettingsDto> jwtSettings,
            SignInManager<User> signInManager,
            IResponseHelperService responseHelper,
            IValidator<RegisterationRequestDto> validatorRegister,
            IMapper mapper,
            IValidator<LoginRequestDto> validatorLogin)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _responseHelper = responseHelper;
            _validatorRegister = validatorRegister;
            _mapper = mapper;
            _validatorLogin = validatorLogin;
        }


        #region Register
        public async Task<OperationResult<RegistrationResponseDto>> Register(RegisterationRequestDto request, CancellationToken cancellationToken = default)
        {
            var response = await _responseHelper.CreateInstance<RegistrationResponseDto>(ResultStatusCodeEnum.SuccessRegister);
            var validationResult = await _validatorRegister.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<User>(request);
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    response.Data = new RegistrationResponseDto() { UserId = user.Id };
                }
                else
                {
                    response.ResultStatusList = new List<ResultStatusModel> { new ResultStatusModel(ResultStatusCodeEnum.CreateUserError) };
                    response.Message = result?.Errors?.ToString() ?? "";
                }
            }
            else
            {
                response = await _responseHelper.HandleValidation(response, validationResult);
            }
            return response;
        }
        #endregion

        public async Task<OperationResult<LoginResponseDto>> Login(LoginRequestDto request, CancellationToken cancellationToken = default)
        {

            var response = await _responseHelper.CreateInstance<LoginResponseDto>(ResultStatusCodeEnum.SuccessLogin);
            response.Data = new LoginResponseDto();
            var validationResult = await _validatorLogin.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
                    var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    var loginResponse = _mapper.Map<LoginResponseDto>(user, opt => opt.Items["token"] = token);
                    response.Data = loginResponse;
                }
                else
                {
                    response.ResultStatusList = new List<ResultStatusModel>
                    {
                        new ResultStatusModel(ResultStatusCodeEnum.UserPassInvalid)
                    };
                }
            }
            else
            {
                response = await _responseHelper.HandleValidation(response, validationResult);

            }
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sid,user.Id.ToString())
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
