using BookShelf.Data.User;
using BookShelf.Models;

namespace BookShelf.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    private UserModel BuildModel(UserDao dto)
    {
        var model = new UserModel
        {
            Id = Guid.Parse(dto.Id),
            Username = dto.Username
        };

        return model;
    }
    
    private UserDao BuildDao(UserModel model)
    {
        var dto = new UserDao
        {
            Id = model.Id.ToString(),
            Username = model.Username,
            Password = model.Password
        };

        return dto;
    }
    
    private void ValidateModel(UserModel model)
    {
        if (model is null)
            throw new Exception("Invalid model instance.");

        if (string.IsNullOrEmpty(model.Password))
            throw new ArgumentNullException(nameof(model.Password), "A password must be informed.");
    }
    
    public async Task<UserModel?> GetUser(string username)
    {
        UserModel result = null;

        var dto = await _repository.GetUser(username);

        if (dto is not null)
            result = BuildModel(dto);

        return result;
    }

    public async Task<Guid> RegisterUser(UserModel model)
    {
        ValidateModel(model);

        var dto = BuildDao(model);

        var userId = await _repository.SaveUser(dto);

        return userId;
    }
}