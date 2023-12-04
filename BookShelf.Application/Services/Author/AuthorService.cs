using BookShelf.Models;

namespace BookShelf.Application.Services.Author;

public class AuthorService : IAuthorService
{
    public AuthorModel GetAuthor(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public List<AuthorModel> GetAuthorsByBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthor(BookModel model)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Guid bookId)
    {
        throw new NotImplementedException();
    }
}