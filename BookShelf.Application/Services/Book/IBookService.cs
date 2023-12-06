using BookShelf.Models;

namespace BookShelf.Application.Services.Book;

public interface IBookService
{
    Task<BookModel?> GetBook(Guid bookId);
    
    Task<Guid> CreateBook(BookModel model);

    Task<bool> UpdateBook(Guid bookId, BookModel model);

    Task<bool> DeleteBook(Guid bookId);
}