using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CustomIdentityUser admin = new CustomIdentityUser()
            {
                Id = 99999,
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin,_configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData( 
                new IdentityRole<int> { 
                    Id = 99999, 
                    Name = "admin",
                    NormalizedName = "ADMIN"
                });
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>
                {
                    Id = 9999,
                    Name = "regular",
                    NormalizedName = "REGULAR"
                });

        }

    }
}
