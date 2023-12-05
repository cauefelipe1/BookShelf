using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public interface IAuthorService
{
    Task<List<AuthorModel>> GetAll();

    Task<AuthorModel?> GetAuthor(Guid authorId);
    
    Task<Guid> CreateAuthor(AuthorModel model);

    Task<List<AuthorModel>> GetAuthorsByBook(Guid bookId);
}