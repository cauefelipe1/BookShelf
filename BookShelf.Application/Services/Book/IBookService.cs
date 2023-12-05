using BookShelf.Models;

namespace BookShelf.Application.Services.Book;

public interface IBookService
{
    BookModel GetBook(Guid bookId);
    
    List<BookModel> GetUserBooks(Guid userId);
    
    Task<Guid> CreateBook(BookModel model);

    void UpdateBook(BookModel model);

    void DeleteBook(Guid bookId);
}