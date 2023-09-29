using Application.Dtos.Auth;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Products;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MappingProfile(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            CreateMap<RegisterationRequestDto, User>()
                .ForMember(des => des.UserName, op => op.MapFrom(src => src.Email))
                .ForMember(des => des.Email, op => op.MapFrom(src => src.Email))
                .ForMember(des => des.EmailConfirmed, op => op.MapFrom(src => true));
            CreateMap<User, LoginResponseDto>()
                .ForMember(des => des.Token,
                     opt => opt.MapFrom(
                     (src, dst, _, context) => context.Items["token"]));
            CreateMap<CreateProductDto, Product>()
            .ForMember(x => x.CreateById, opt => opt.MapFrom(scr => _httpContextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Sid)))
            .ForMember(x => x.Id, opt => opt.MapFrom(scr => Guid.NewGuid()))
            .ForMember(x => x.IsAvailable, opt => opt.MapFrom(scr => true));

            CreateMap<UpdateProductDto, Product>()
            .ForMember(x => x.CreateById, opt => opt.MapFrom(scr => _httpContextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Sid)));
            CreateMap<Product, ProductDto>()
                .ForMember(des => des.ProduceDate, op => op.MapFrom(src => src.ProduceDate.ToString("yyyy/MM/dd")));
        }
    }
}
