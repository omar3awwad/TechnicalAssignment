using TechnicalAssignment.Api.Data;
using Microsoft.EntityFrameworkCore;
using TechnicalAssignment.Api.Data.Services.DbInitializer;
using TechnicalAssignment.Api.Services.Interfaces;
using TechnicalAssignment.Api.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IDbInitializerService, DbInitializerService>();
builder.Services.AddScoped<IMakeService, MakeService>();
builder.Services.AddScoped<IIntegrationService, IntegrationService>();

builder.Services.AddDbContext<ApplicationDbContext>(
     options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Technical Assignment",
        Version = "v1",
        Description = "Technical Assignment"
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    var services = scope.ServiceProvider;
    try
    {
        var dbInitializer = services.GetRequiredService<IDbInitializerService>();
        dbInitializer.Migrate();
        dbInitializer.Seed();

        logger.LogInformation("Database initialization completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred during database initialization.");
    }
}

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Technical Assignment");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
