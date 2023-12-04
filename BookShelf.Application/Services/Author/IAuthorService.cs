using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public interface IAuthorService
{
    AuthorModel GetAuthor(Guid authorId);

    List<AuthorModel> GetAuthorsByBook(Guid bookId);

    void UpdateAuthor(BookModel model);

    void DeleteAuthor(Guid bookId);
}