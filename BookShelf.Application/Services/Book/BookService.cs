using BookShelf.Models;

namespace BookShelf.Application.Services;

public class BookService : IBookService
{
    public BookModel GetBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public List<BookModel> GetUserBooks(Guid userId)
    {
        throw new NotImplementedException();
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