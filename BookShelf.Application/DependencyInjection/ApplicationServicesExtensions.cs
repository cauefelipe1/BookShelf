using System.Text;
using BookShelf.Application.Services.Authentication;
using BookShelf.Application.Services.Author;
using BookShelf.Application.Services.Book;
using BookShelf.Application.Services.Jwt;
using BookShelf.Application.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookShelf.Application.DependencyInjection;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
    }
    
    public static void AddJwtToken(this IServiceCollection services, JwtSettings jwtSettings)
    {
        var tokenValidationParameters = GetTokenValidationParameters(jwtSettings);
        
        services.AddSingleton(tokenValidationParameters);

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });
    }
    
    private static TokenValidationParameters GetTokenValidationParameters(JwtSettings jwtSettings)
    {
        var result = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };

        return result;
    }
}