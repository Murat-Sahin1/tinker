using tinker.Application.Interfaces.Repositories;
using tinker.Persistence;
using tinker.Persistence.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var categoryRepository = services.GetService<ICategoryRepository>();

        await DbInitializer.seedCategoryData(categoryRepository);

    } catch (Exception ex)
    {
        Console.WriteLine("Exception occured while trying to get a service in Program.cs", ex.Message);
        throw;
    }
}

app.Run();
