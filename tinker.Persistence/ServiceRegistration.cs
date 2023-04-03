using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tinker.Persistence.Configurations;
using tinker.Persistence.Contexts;

namespace tinker.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(Configuration.InMemoryConnectionString));
        }
    }
}
