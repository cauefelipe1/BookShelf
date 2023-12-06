using BookShelf.Data.Base;
using BookShelf.Data.Settings;
using Npgsql;

namespace BookShelf.Data.User
{
    public class UserAdoRepository : BaseAdoRepository, IUserRepository
    {
        private readonly DatabaseSettings _settings;

        const string SELECT_USER = @"
            SELECT
                id,
                UserName, 
                Password
            FROM
                ""user""
            WHERE
                Username = @Username";

        public UserAdoRepository(DatabaseSettings settings) => _settings = settings;

        /// <inheritdoc cref="IUserRepository.GetUser(string)"/>
        public async Task<UserDao?> GetUser(string username)
        {
            using (var conn = new NpgsqlConnection(_settings.ConnectionString))
            {
                conn.Open();
                var daos = await ExecuteQuery<UserDao>(conn, SELECT_USER, new { Username = username });

                await conn.CloseAsync();

                if (daos.Count == 0)
                    return null;

                return daos.First();
            }
        }

        const string INSERT_USER = @"
                INSERT INTO ""user"" (
                    id,
                    username, 
                    password
                ) 
                VALUES (
                    @Id,
                    @Username, 
                    @Password
                );";

        /// <inheritdoc cref="IUserRepository.SaveUser(UserDao)"/>
        public async Task<Guid> SaveUser(UserDao dao)
        {
            var id = Guid.NewGuid();
            dao.Id = id.ToString();

            using (var conn = new NpgsqlConnection(_settings.ConnectionString))
            {
                conn.Open();
                await ExecuteNonQuery(conn, INSERT_USER, dao);

                await conn.CloseAsync();

                return id;
            }
        }
    }
}
