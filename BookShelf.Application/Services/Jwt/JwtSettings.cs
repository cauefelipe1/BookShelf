using Microsoft.Extensions.Configuration;

namespace BookShelf.Application.Services.Jwt;

public class JwtSettings
{
    public string Secret { get; }

    public string Issuer { get; }

    public string Audience { get; }

    public int Expiration { get; }

    public JwtSettings(IConfigurationSection configuration)
    {
        Secret = configuration[nameof(Secret)];
        Issuer = configuration[nameof(Issuer)];
        Audience = configuration[nameof(Audience)];
        Expiration = int.Parse(configuration[nameof(Expiration)]);
    }
}