using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VermilionTimeline.IdentityDataAccess
{
    public class IdentityDbContext: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Initial roles
            var adminRoleId = "dc2bb782-be50-4a99-87f7-5515457cc680";
            var userRoleId = "b54918b5-eb1a-42c2-907e-594850d52ba2";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name= "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Initial 914173725@qq.com user
            var adminId = "39f847c1-01a9-44ce-b1a8-7c667f6efe73";
            var admin = new IdentityUser
            {
                UserName = "914173725@qq.com",
                Email = "914173725@qq.com",
                NormalizedEmail = "914173725@qq.com".ToUpper(),
                NormalizedUserName = "914173725@qq.com".ToUpper(),
                Id = adminId
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(admin, "VermiliontimelineAdmin@@@2050");
            builder.Entity<IdentityUser>().HasData(admin);

            // Grant admin to 914173725@qq.com user
            var adminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
