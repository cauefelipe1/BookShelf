using Microsoft.Extensions.Configuration;

namespace BookShelf.Data.Settings;

public class DatabaseSettings
{
    /// <summary>
    /// Host address for the database.
    /// </summary>
    public string Host { get; } = default!;

    /// <summary>
    /// Port number the <see cref="Host"/> is listen to.
    /// </summary>
    public int Port { get; }

    /// <summary>
    /// Name of the database.
    /// </summary>
    public string DatabaseName { get; } = default!;

     /// <summary>
     /// User to connect to the database.
     /// </summary>
    public string User { get; } = default!;

    /// <summary>
    /// Password to connect to the database.
    /// </summary>
    public string Password { get; } = default!;

    private string _connectionString = default!;
    

    /// <summary>
    /// Formatted connection string the driver will use to connect to the database.
    /// </summary>
    public string ConnectionString
    {
        get
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString =
                    $"Username={User};Password={Password};Host={Host};Port={Port};Database={DatabaseName}";
#if DEBUG
                _connectionString += ";IncludeErrorDetail=true";
#endif
            }

            return _connectionString;
        }
    }

    /// <summary>
    /// Class constructor.
    /// </summary>
    public DatabaseSettings(IConfigurationSection configuration)
    {
        if (configuration is not null)
        {
            Host = configuration[nameof(Host)];
            Port = Convert.ToInt32(configuration[nameof(Port)]);
            DatabaseName = configuration[nameof(DatabaseName)];
            User = configuration[nameof(User)];
            Password = configuration[nameof(Password)];
        }
    }
}