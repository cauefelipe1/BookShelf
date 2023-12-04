using BookShelf.Models;

namespace BookShelf.Application.Services;

public interface IBookService
{
    BookModel GetBook(Guid bookId);
    
    List<BookModel> GetUserBooks(Guid userId);

    void UpdateBook(BookModel model);

    void DeleteBook(Guid bookId);
}