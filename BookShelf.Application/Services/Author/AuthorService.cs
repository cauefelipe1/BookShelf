using BookShelf.Data.Author;
using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    private AuthorDao BuildDao(AuthorModel model)
    {
        var dao = new AuthorDao
        {
            Id = model.Id.ToString(),
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        return dao;
    }
    
    private AuthorModel BuildModel(AuthorDao dao)
    {
        var model = new AuthorModel
        {
            Id = Guid.Parse(dao.Id),
            FirstName = dao.FirstName,
            LastName = dao.LastName
        };

        return model;
    }

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthorModel?> GetAuthor(Guid authorId)
    {
        var dao = await _repository.GetAuthor(authorId);
        AuthorModel? author = null;

        if (dao is not null)
            author = BuildModel(dao);

        return author;
    }

    public async Task<Guid> CreateAuthor(AuthorModel model)
    {
        var dao = BuildDao(model);

        var id = await _repository.CreateAuthor(dao);

        return id;
    }

    public async Task<List<AuthorModel>> GetAuthorsByBook(Guid bookId)
    {
        var daos = await _repository.GetAuthorsByBook(bookId);
        List<AuthorModel> authors;

        if (daos.Count > 0)
            authors = daos.Select(dao => BuildModel(dao)).ToList();
        else
            authors = new List<AuthorModel>();
        
        return authors;
    }
}