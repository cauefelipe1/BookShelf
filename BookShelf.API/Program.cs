using BookShelf.API.DependencyInjection;
using BookShelf.Application.DependencyInjection;
using BookShelf.Application.Services.Jwt;
using BookShelf.Data.DependencyInjection;
using BookShelf.Data.Settings;

namespace BookShelf.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger();
        
        builder.Services.AddDomainServices();
        builder.Configuration.AddEnvironmentVariables();
        
        builder.Services.AddDatabaseConfiguration(builder.Configuration);
        var jwtSettings = builder.Services.AddJwtConfiguration(builder.Configuration);
        builder.Services.AddJwtToken(jwtSettings);
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }

    private static void AddDomainServices(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddRepositories();
    }
    
    private static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseSettings = new DatabaseSettings(configuration.GetSection("Database"));

        services.AddSingleton(databaseSettings);
    }
    
    private static JwtSettings AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings(configuration.GetSection("JwtSettings"));

        services.AddSingleton(jwtSettings);

        return jwtSettings;
    }
}