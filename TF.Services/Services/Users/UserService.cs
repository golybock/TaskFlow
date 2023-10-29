using TF.BlankModels.Models.User;
using TF.Repositories.Repositories.Users;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<UserView?> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserView?> GetUserAsync(string usernameOrEmail)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateUserAsync(UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateUserAsync(Guid id, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateUserAsync(string usernameOrEmail, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUserAsync(string username)
    {
        throw new NotImplementedException();
    }
}