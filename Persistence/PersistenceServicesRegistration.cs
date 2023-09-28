using Application.Contracts.Persistence.Base;
using Application.Contracts.Persistence.Products;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Base;
using Persistence.Repositories.Products;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("RayanboursConnection");
            services.AddDbContext<RayanbourseDbContext>(item => item.UseSqlServer(connString));
            services.AddIdentity<User, IdentityRole>()
                            .AddEntityFrameworkStores<RayanbourseDbContext>().AddDefaultTokenProviders();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
