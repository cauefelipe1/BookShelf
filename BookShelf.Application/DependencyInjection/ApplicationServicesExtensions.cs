using BookShelf.Application.Services.Author;
using BookShelf.Application.Services.Book;
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