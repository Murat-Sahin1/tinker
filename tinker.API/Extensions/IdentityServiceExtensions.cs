using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using tinker.Application.Interfaces;
using tinker.Domain.Entities.Identity;
using tinker.Infrastructure.Repositories;
using tinker.Persistence.Identity;

namespace tinker.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(config["ApplicationSettings:ConnectionStrings:SqlServerConnection"]);
            });

            services.AddScoped<ITokenService, TokenService>();

            services.AddIdentityCore<AppUser>(opt =>
            {
                // identity options
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["ApplicationSettings:Token:Key"])),
                        ValidIssuer = config["ApplicationSettings:Token:Issuer"],
                        ValidateIssuer = true
                    };
                });

            services.AddAuthorizationCore();

            return services;
        }
    }
}
