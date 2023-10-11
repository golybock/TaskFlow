using TF.BlankModels.Models.User;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Users;

public interface IUserService
{
    public Task<UserView?> GetUserAsync(Guid id);

    public Task<UserView?> GetUserAsync(String usernameOrEmail);

    public Task<Guid> CreateUserAsync(UserBlank userDatabase);

    public Task<Int32> UpdateUserAsync(Guid id, UserBlank userDatabase);

    public Task<Int32> UpdateUserAsync(String usernameOrEmail, UserBlank userDatabase);

    public Task<Int32> DeleteUserAsync(Guid id);

    public Task<Int32> DeleteUserAsync(String username);
}