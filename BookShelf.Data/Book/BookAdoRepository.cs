using BookShelf.Data.Base;
using BookShelf.Data.Settings;
using Npgsql;

namespace BookShelf.Data.Book;

public class BookAdoRepository : BaseAdoRepository, IBookRepository
{
    private readonly DatabaseSettings _settings;

    public BookAdoRepository(DatabaseSettings settings)
    {
        _settings = settings;
    }

    public async Task<BookDao?> GetBook(Guid bookId)
    {
        const string SQL = @"
            SELECT 
                id AS Id,
                isbn AS Isbn,
                title AS Title,
                publish_date As PublishDate,
                language as Language
            FROM
                book
            WHERE
                id = @id;";

        using (var conn = new NpgsqlConnection(_settings.ConnectionString))
        {
            conn.Open();
            
            var daos = await ExecuteQuery<BookDao>(conn, SQL, parameters: new {id = bookId.ToString()});
            
            await conn.CloseAsync();

            if (daos.Count == 0)
                return null;
            
            return daos.First();
        }
    }

    public Task<List<BookDao>> GetUserBooks(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateBook(BookDao dao)
    {
        const string SQL = @"
            INSERT INTO 
                book
                (id, isbn, title, publish_date, language)
            VALUES
                (@Id, @Isbn, @Title, @PublishDate, @Language);";

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

    public Task UpdateBook(BookDao dao)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBook(Guid bookId)
    {
        throw new NotImplementedException();
    }
}