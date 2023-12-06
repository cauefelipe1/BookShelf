using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BookShelf.Application.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings) => _jwtSettings = jwtSettings;

        /// <inheritdoc cref="IJwtService.GenerateJwtToken(IReadOnlyDictionary{string, string})"/>
        public TokenInfo GenerateJwtToken(IReadOnlyDictionary<string, string> payload)
        {
            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = payload.Select(p => new Claim(p.Key, p.Value));
            var tokenExpiration = DateTime.UtcNow.AddSeconds(_jwtSettings.Expiration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = tokenExpiration,
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            string jwtToken = tokenHandler.WriteToken(securityToken);

            var result = new TokenInfo("Bearer", jwtToken, tokenExpiration);

            return result;
        }
    }
}
