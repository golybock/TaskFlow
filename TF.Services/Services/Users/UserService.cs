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

    public async Task<Guid> CreateUserAsync(UserBlank userDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateUserAsync(Guid id, UserBlank userDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateUserAsync(string usernameOrEmail, UserBlank userDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteUserAsync(string username)
    {
        throw new NotImplementedException();
    }
}