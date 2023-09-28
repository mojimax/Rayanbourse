using Application.Contracts.General;
using Application.Contracts.Services.Auth;
using Application.Contracts.Services.Poducts;
using Application.Contracts.Services.Users;
using Application.Dtos.Auth.Validations;
using Application.Profiles;
using Application.Services.Auth;
using Application.Services.General;
using Application.Services.Products;
using Application.Services.Users;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, IHttpContextAccessor httpContextAccessor)
        {
            var automapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new MappingProfile(httpContextAccessor));
            });
            var autoMapper = automapperConfig.CreateMapper();
            services.AddSingleton(autoMapper);
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserSerive, UserService>();
            services.AddScoped<IResponseHelperService, ResponseHelperService>();
            services.AddValidatorsFromAssemblyContaining<RegisterationRequestValidator>();

        }
    }
}
