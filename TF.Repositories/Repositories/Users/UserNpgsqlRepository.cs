using Npgsql;
using TF.DatabaseModels.Models.User;
using TF.Repositories.Reader;

namespace TF.Repositories.Repositories.Users;

public class UserNpgsqlRepository : NpgsqlRepository, IUserRepository
{
    public UserNpgsqlRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<UserDatabase?> GetUserAsync(Guid id)
    {
        string query = "select * from users where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = id}
        };

        return await GetAsync<UserDatabase>(query, parameters);
    }

    public async Task<UserDatabase?> GetUserAsync(string usernameOrEmail)
    {
        string query = "select * from users where username = $1 or email = $1";

        var connection = GetConnection();

        var parameters = new[]
        {
            new NpgsqlParameter{Value = usernameOrEmail}
        };

        return await GetAsync<UserDatabase>(query, parameters);
    }

    public async Task<Guid> CreateUserAsync(UserDatabase userDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateUserAsync(Guid id, UserDatabase userDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateUserAsync(string usernameOrEmail, UserDatabase userDatabase)
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