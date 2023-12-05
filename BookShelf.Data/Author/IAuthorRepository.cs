namespace BookShelf.Data.Author;

public interface IAuthorRepository
{
    Task<AuthorDao?> GetAuthor(Guid authorId);

    Task<List<AuthorDao>> GetAuthorsByBook(Guid bookId);
    
    Task<Guid> CreateAuthor(AuthorDao dao);
}