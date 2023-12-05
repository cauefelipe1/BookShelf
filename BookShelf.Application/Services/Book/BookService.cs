using BookShelf.Data.Book;
using BookShelf.Models;

namespace BookShelf.Application.Services.Book;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    
    private BookDao BuildDao(BookModel model)
    {
        var dao = new BookDao
        {
            Id = model.Id.ToString(),
            Isbn = model.Isbn,
            Title = model.Title,
            PublishDate = model.PublishDate,
            Language = model.Language
        };

        return dao;
    }
    
    private BookModel BuildModel(BookDao dao)
    {
        var model = new BookModel
        {
            Id = Guid.Parse(dao.Id),
            Isbn = dao.Isbn,
            Title = dao.Title,
            PublishDate = dao.PublishDate,
            Language = dao.Language
        };

        return model;
    }

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public BookModel GetBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public List<BookModel> GetUserBooks(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateBook(BookModel model)
    {
        var dao = BuildDao(model);
        
        var id = await _repository.CreateBook(dao);

        return id;
    }

    public void UpdateBook(BookModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(Guid bookId)
    {
        throw new NotImplementedException();
    }
}