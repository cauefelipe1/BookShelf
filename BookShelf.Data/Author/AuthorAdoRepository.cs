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

    public async Task<AuthorDao?> GetAuthor(Guid authorId)
    {
        const string SQL = @"
            SELECT 
                id AS Id, 
                first_name AS FirstName, 
                last_date AS LastName
            FROM 
                author
            WHERE
                id = @id;";

        using (var conn = new NpgsqlConnection(_settings.ConnectionString))
        {
            conn.Open();
            
            var daos = await ExecuteQuery<AuthorDao>(conn, SQL, parameters: new {id = authorId.ToString()});
            
            await conn.CloseAsync();

            if (daos.Count == 0)
                return null;
            
            return daos.First();
        }
    }

    public Task<List<AuthorDao>> GetAuthorsByBook(Guid bookId)
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
}