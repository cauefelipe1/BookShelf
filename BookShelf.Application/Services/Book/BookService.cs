using BookShelf.Application.Services.Author;
using BookShelf.Data.Book;
using BookShelf.Models;

namespace BookShelf.Application.Services.Book;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IAuthorService _authorService;
    
    public BookService(IBookRepository repository, IAuthorService authorService)
    {
        _repository = repository;
        _authorService = authorService;
    }
    
    private BookDao BuildDao(BookModel model)
    {
        var dao = new BookDao
        {
            Id = model.Id.ToString(),
            Isbn = model.Isbn,
            Title = model.Title,
            PublishDate = model.PublishDate,
            Language = model.Language,
            Auhtors = model.Authors.Select(a => a.Id.ToString()).ToList()
        };

        return dao;
    }
    
    private BookModel BuildModel(BookDao dao, List<AuthorModel> authors)
    {
        var model = new BookModel
        {
            Id = Guid.Parse(dao.Id),
            Isbn = dao.Isbn,
            Title = dao.Title,
            PublishDate = dao.PublishDate,
            Language = dao.Language,
            Authors = authors
        };

        return model;
    }

    public async Task<BookModel?> GetBook(Guid bookId)
    {
        var dao = await _repository.GetBook(bookId);
        BookModel? author = null;

        if (dao is not null)
        {
            var authors = await _authorService.GetAuthorsByBook(bookId);
            author = BuildModel(dao, authors);
        }

        return author;
    }

    public Task<List<BookModel>> GetUserBooks(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateBook(BookModel model)
    {
        var dao = BuildDao(model);
        
        var id = await _repository.CreateBook(dao);

        return id;
    }

    public async Task<bool> UpdateBook(Guid bookId, BookModel model)
    {
        var dao = BuildDao(model);
        
        var updated = await _repository.UpdateBook(dao);

        return updated;
    }

    public Task<bool> DeleteBook(Guid bookId)
    {
        throw new NotImplementedException();
    }
}