using BookShelf.Application.Services.Jwt;
using BookShelf.Application.Services.User;
using BookShelf.Models;
using BookShelf.Models.Authentication;

namespace BookShelf.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;

    public AuthenticationService(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    public async Task<TokenInfo> AuthenticateUser(LoginModel model)
    {
        string username = model.Username;
        
        var user = await _userService.GetUser(username);

        if (user is null)
            throw new Exception("Invalid username and/or password.");
        
        var token = GetUserTokenInfo(user, _jwtService);

        return token;
    }
    
    public async Task<TokenInfo> RegisterUser(LoginModel model)
    {
        string username = model.Username;
        
        var user = await _userService.GetUser(username);

        if (user is not null)
            throw new Exception("User already exists");

        user = new UserModel
        {
            Username = model.Username,
            Password = model.Password
        };

        user.Id = await _userService.RegisterUser(user);
        
        var token = GetUserTokenInfo(user, _jwtService);

        return token;
    }
    
    private static TokenInfo GetUserTokenInfo(UserModel user, IJwtService jwtService)
    {
        var claims = new Dictionary<string, string>
        {
            [nameof(IdentityClaimsModel.UserId)] = user.Id.ToString(),
            [nameof(IdentityClaimsModel.Username)] = user.Username
        };

        var token = jwtService.GenerateJwtToken(claims);

        return token;
    }
}