using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Configuration;
using tinker.Application;
using tinker.Application.Interfaces.Repositories;
using tinker.Persistence;
using tinker.Persistence.Seeds;



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

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");
//app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var categoryRepository = services.GetService<ICategoryRepository>();
        var productRepository = services.GetService<IProductRepository>();

        await DbInitializer.seedCategoryData(categoryRepository);
        await DbInitializer.seedProductData(productRepository, categoryRepository);

    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception occured while trying to get a service in Program.cs", ex.Message);
        throw;
    }
}

app.Run();