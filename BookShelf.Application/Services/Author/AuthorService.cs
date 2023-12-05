using BookShelf.Data.Author;
using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    private AuthorDao CreateDao(AuthorModel model)
    {
        var dao = new AuthorDao
        {
            Id = model.Id.ToString(),
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        return dao;
    }

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public AuthorModel GetAuthor(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateAuthor(AuthorModel model)
    {
        var dao = CreateDao(model);

        var id = await _repository.CreateAuthor(dao);

        return id;
    }

    public List<AuthorModel> GetAuthorsByBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthor(AuthorModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Guid authorId)
    {
        throw new NotImplementedException();
    }
}