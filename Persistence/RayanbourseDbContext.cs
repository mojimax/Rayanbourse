using Domain.Products;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;

namespace Persistence
{
    public class RayanbourseDbContext : IdentityDbContext<User>
    {
        public RayanbourseDbContext(DbContextOptions<RayanbourseDbContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .ApplyConfigurationsFromAssembly(typeof(RayanbourseDbContext).Assembly);
        }

    }
}
