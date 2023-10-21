using TF.DatabaseModels.Models.User;

namespace TF.Repositories.Repositories.Users;

public interface IUserRepository
{
    public Task<UserDatabase?> GetUserAsync(Guid id);

    public Task<UserDatabase?> GetUserAsync(String usernameOrEmail);

    public Task<Boolean> CreateUserAsync(UserDatabase userDatabase);

    public Task<Boolean> UpdateUserAsync(Guid id, UserDatabase userDatabase);

    public Task<Boolean> UpdateUserAsync(String usernameOrEmail, UserDatabase userDatabase);

    public Task<Boolean> DeleteUserAsync(Guid id);

    public Task<Boolean> DeleteUserAsync(String username);
}