using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            builder.HasData(new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName = "Admin",
                EmailConfirmed = true,
                NormalizedEmail = "admin@gmail.com",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PasswordHash = passwordHasher.HashPassword(null, "Qwerty1234!")
            }, new User
            {
                Id = "b421e928-0613-9ebd-a64c-f10b6a706e73",
                UserName = "user",
                NormalizedUserName = "user",
                EmailConfirmed = true,
                NormalizedEmail = "adam@gmail.com",
                Email = "adam@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                PasswordHash = passwordHasher.HashPassword(null, "Qwerty1234!")
            });
        }
    }
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "ADMINISTRATOR",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMINISTRATOR"
                });
        }
    }

    public class UserRoleConfiguraion : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                }, 
                new IdentityUserRole<string>
                {
                    RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                    UserId = "b421e928-0613-9ebd-a64c-f10b6a706e73"
                });
        }
    }
}
