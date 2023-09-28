using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            var hasher = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = "7e085c90-abd9-4787-854a-6aff8c748cc3",
                    Email = "Mojtabagarmabdarii@gmail.com",
                    NormalizedEmail = "MOJTABAGARMABDARII@GMAIL.COM",
                    UserName = "mojtabagarmabdarii@gmail.com",
                    NormalizedUserName = "MOJTABAGARMABDARII@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Aa123456@"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
