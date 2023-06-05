using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities.Identity;
using tinker.Persistence.Configurations;
using tinker.Persistence.Contexts;
using tinker.Persistence.Identity;
using tinker.Persistence.Repositories;

namespace tinker.Persistence
{
    public static class ServiceRegistration
    {
        public static ApplicationSettings _settings;
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(_settings.ConnectionStrings["InMemoryDatabase"]));

            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(_settings.ConnectionStrings["SqlServerConnection"]);
            });

            services.AddIdentityCore<AppUser>(opt =>
            {
                // identity options
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorizationCore();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();

        }
    }
}
