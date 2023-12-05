namespace BookShelf.Data.Book;

public interface IBookRepository
{
    Task<BookDao?> GetBook(Guid bookId);
    
    Task<List<BookDao>> GetUserBooks(Guid userId);
    
    Task<Guid> CreateBook(BookDao dao);

    Task<bool> UpdateBook(BookDao dao);

    Task<bool> DeleteBook(Guid bookId);
}