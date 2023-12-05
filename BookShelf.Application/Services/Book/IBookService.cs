using BookShelf.Models;

namespace BookShelf.Application.Services.Book;

public interface IBookService
{
    Task<BookModel?> GetBook(Guid bookId);
    
    Task<List<BookModel>> GetUserBooks(Guid userId);
    
    Task<Guid> CreateBook(BookModel model);

    Task UpdateBook(BookModel model);

    Task DeleteBook(Guid bookId);
}