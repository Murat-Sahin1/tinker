using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using tinker.API.Extensions;
using tinker.Application;
using tinker.Application.Interfaces.Repositories;
using tinker.Domain.Entities.Identity;
using tinker.Infrastructure;
using tinker.Persistence;
using tinker.Persistence.Identity;
using tinker.Persistence.Seeds;
using tinker.Persistence.Seeds.IdentitySeeds;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => {
            builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        });
});
builder.Services.AddControllers();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();

        configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configurationRoot = configuration.Build();

        ApplicationSettings options = new();
        configurationRoot.GetSection(nameof(ApplicationSettings))
                         .Bind(options);

        tinker.Persistence.ServiceRegistration._settings = options;
    })
    .Build();

builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Issue solved with DTOs.
// builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();


    try
    {
        var categoryRepository = services.GetService<ICategoryRepository>();
        var productRepository = services.GetService<IProductRepository>();

        await DbInitializer.seedCategoryData(categoryRepository);
        await DbInitializer.seedProductData(productRepository, categoryRepository);

        await identityContext.Database.MigrateAsync(); // same as database-update
        await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception occured while trying to get a service in Program.cs", ex.Message);
        throw;
    }
}

app.Run();