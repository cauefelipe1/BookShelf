using BookShelf.Data.Author;
using BookShelf.Data.Book;
using Microsoft.Extensions.DependencyInjection;

namespace BookShelf.Data.DependencyInjection;

public static class DataDependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorRepository, AuthorAdoRepository>();
        services.AddSingleton<IBookRepository, BookAdoRepository>();
    }
}