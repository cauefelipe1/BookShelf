using BookShelf.Models;

namespace BookShelf.Application.Services.User;

public interface IUserService
{
    Task<UserModel?> GetUser(string username);
    Task<Guid> RegisterUser(UserModel model);
}