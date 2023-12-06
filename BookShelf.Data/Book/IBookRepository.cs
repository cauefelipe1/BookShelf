namespace BookShelf.Data.Book;

public interface IBookRepository
{
    Task<List<BookDao>> GetAll();
    
    Task<BookDao?> GetBook(Guid bookId);
    
    Task<Guid> CreateBook(BookDao dao);

    Task<bool> UpdateBook(BookDao dao);

    Task<bool> DeleteBook(Guid bookId);
}