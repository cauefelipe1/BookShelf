namespace BookShelf.Data.Book;

public interface IBookRepository
{
    Task<BookDao?> GetBook(Guid bookId);
    
    Task<List<BookDao>> GetUserBooks(Guid userId);
    
    Task<Guid> CreateBook(BookDao dao);

    Task UpdateBook(BookDao dao);

    Task DeleteBook(Guid bookId);
}