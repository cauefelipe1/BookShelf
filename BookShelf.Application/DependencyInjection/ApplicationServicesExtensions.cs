using BookShelf.Application.Services.Authentication;
using BookShelf.Application.Services.Author;
using BookShelf.Application.Services.Book;
using BookShelf.Application.Services.Jwt;
using BookShelf.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

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
}