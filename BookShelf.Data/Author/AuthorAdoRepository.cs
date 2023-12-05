using BookShelf.Data.Base;
using BookShelf.Data.Settings;
using Npgsql;

namespace BookShelf.Data.Author;

public class AuthorAdoRepository : BaseAdoRepository, IAuthorRepository
{
    private readonly DatabaseSettings _settings;

    public AuthorAdoRepository(DatabaseSettings settings)
    {
        _settings = settings;
    }

    public AuthorDao GetAuthor(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public List<AuthorDao> GetAuthorsByBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateAuthor(AuthorDao dao)
    {
        const string SQL = @"
            INSERT INTO public.author
                (id, first_name, last_date)
            VALUES
                (@Id, @FirstName, @LastName);
            ";

        var id = Guid.NewGuid(); 
        dao.Id = id.ToString();

        using (var conn = new NpgsqlConnection(_settings.ConnectionString))
        {
            conn.Open();
            
            await ExecuteNonQuery(conn, SQL, parameters: dao);
            
            await conn.CloseAsync();
            
            return id;
        }
    }

    public void UpdateAuthor(AuthorDao dao)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Guid authorId)
    {
        throw new NotImplementedException();
    }
}