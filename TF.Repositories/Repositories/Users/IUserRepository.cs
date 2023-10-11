using TF.DatabaseModels.Models.User;

namespace TF.Repositories.Repositories.Users;

public interface IUserRepository
{
    public Task<UserDatabase?> GetUserAsync(Guid id);

    public Task<UserDatabase?> GetUserAsync(String usernameOrEmail);

    public Task<Guid> CreateUserAsync(UserDatabase userDatabase);

    public Task<Int32> UpdateUserAsync(Guid id, UserDatabase userDatabase);

    public Task<Int32> UpdateUserAsync(String usernameOrEmail, UserDatabase userDatabase);

    public Task<Int32> DeleteUserAsync(Guid id);

    public Task<Int32> DeleteUserAsync(String username);
}