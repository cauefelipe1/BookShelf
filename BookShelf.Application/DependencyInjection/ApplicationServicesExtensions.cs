using BookShelf.Application.Services;
using BookShelf.Application.Services.Author;
using Microsoft.Extensions.DependencyInjection;

namespace BookShelf.Application.DependencyInjection;

public static class ApplicationServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
    }
}