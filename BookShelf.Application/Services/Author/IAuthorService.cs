using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public interface IAuthorService
{
    AuthorModel GetAuthor(Guid authorId);
    
    Task<Guid> CreateAuthor(AuthorModel model);

    List<AuthorModel> GetAuthorsByBook(Guid bookId);

    void UpdateAuthor(AuthorModel model);

    void DeleteAuthor(Guid authorId);
}