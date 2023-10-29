using TF.BlankModels.Models.User;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Users;

public interface IUserService
{
    public Task<UserView?> GetUserAsync(Guid id);

    public Task<UserView?> GetUserAsync(String usernameOrEmail);

    public Task<Boolean> CreateUserAsync(UserBlank userBlank);

    public Task<Boolean> UpdateUserAsync(Guid id, UserBlank userBlank);

    public Task<Boolean> UpdateUserAsync(String usernameOrEmail, UserBlank userBlank);

    public Task<Boolean> DeleteUserAsync(Guid id);

    public Task<Boolean> DeleteUserAsync(String username);
}