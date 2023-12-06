using BookShelf.Data.Author;
using BookShelf.Data.Book;
using BookShelf.Data.User;
using Microsoft.Extensions.DependencyInjection;

namespace BookShelf.Data.DependencyInjection;

public static class DataDependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorRepository, AuthorAdoRepository>();
        services.AddSingleton<IBookRepository, BookAdoRepository>();
        services.AddSingleton<IUserRepository, UserAdoRepository>();
    }
}