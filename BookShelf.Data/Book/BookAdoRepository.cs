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
            
            int rowAffected = await ExecuteNonQuery(conn, SQL, parameters: dao);
            
            if (rowAffected > 0)
                await InternalUpdateBookAuthors(conn, dao);
            
            await conn.CloseAsync();
            
            return id;
        }
    }

    public async Task<bool> UpdateBook(BookDao dao)
    {
        const string SQL = @"
            UPDATE
                book
            SET
                isbn = @Isbn,
                title = @Title,
                publish_date = @PublishDate,
                language = @Language
            WHERE
                id = @Id";

        using (var conn = new NpgsqlConnection(_settings.ConnectionString))
        {
            conn.Open();
            
            int rowAffected = await ExecuteNonQuery(conn, SQL, parameters: dao);

            if (rowAffected > 0)
                await InternalUpdateBookAuthors(conn, dao);
            
            await conn.CloseAsync();

            return rowAffected > 0;
        }
    }

    private async Task InternalUpdateBookAuthors(NpgsqlConnection conn, BookDao dao)
    {
        const string DELETE_SQL = "DELETE FROM book_author WHERE book_id = @BookId";
        
        const string INSERT_SQL = @"
            INSERT INTO 
                book_author
                (book_id, author_id)
            VALUES
                (@BookId, @AuthorId);";

        foreach (var a in dao.Auhtors)
        {
            await ExecuteNonQuery(conn, INSERT_SQL, parameters: new {BookId = dao.Id, AuthorId = a});    
        }
    }

    public Task<bool> DeleteBook(Guid bookId)
    {
        throw new NotImplementedException();
    }
}