using BookShelf.Application.Services.Jwt;
using BookShelf.Models.Authentication;

namespace BookShelf.Application.Services.Authentication;

public interface IAuthenticationService
{
    Task<TokenInfo> AuthenticateUser(LoginModel model);
    Task<TokenInfo> RegisterUser(LoginModel model);
}