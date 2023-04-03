using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tinker.Application.Interfaces.Repositories;
using tinker.Persistence.Configurations;
using tinker.Persistence.Contexts;
using tinker.Persistence.Repositories;

namespace tinker.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(ConfigManager.InMemoryConnectionString));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
        }
    }
}
