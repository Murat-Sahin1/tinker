using Microsoft.EntityFrameworkCore;
using tinker.Persistence.Identity;

namespace tinker.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(config.GetConnectionString("IdentityConnection"));
            });

            return services;
        }
    }
}
