using Npgsql;
using TF.DatabaseModels.Models.User;

namespace TF.Repositories.Repositories.Users;

public class UserRepository : NpgsqlRepository, IUserRepository
{
    public UserRepository(string connectionString) : base(connectionString) { }

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

        var parameters = new[]
        {
            new NpgsqlParameter{Value = usernameOrEmail}
        };

        return await GetAsync<UserDatabase>(query, parameters);
    }

    public async Task<Boolean> CreateUserAsync(UserDatabase userDatabase)
    {
        string query = "insert into users(id, full_name, username, email, password, letters, image_url, role_id)" +
                       "values($1, $2, $3, $4, $5, $6, $7, $8)";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = userDatabase.Id},
            new NpgsqlParameter{Value = userDatabase.FullName},
            new NpgsqlParameter{Value = userDatabase.Username},
            new NpgsqlParameter{Value = userDatabase.Email},
            new NpgsqlParameter{Value = userDatabase.Password},
            new NpgsqlParameter{Value = userDatabase.Letters},
            new NpgsqlParameter{Value = userDatabase.ImageUrl},
            new NpgsqlParameter{Value = (object) userDatabase.RoleId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> UpdateUserAsync(Guid id, UserDatabase userDatabase)
    {
        string query = "update users set " +
                       "full_name = $2, email = $4, " +
                       "password = $5, letters = $6, " +
                       "image_url = $7, role_id = $8 " +
                       "where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = userDatabase.Id},
            new NpgsqlParameter{Value = userDatabase.FullName},
            new NpgsqlParameter{Value = userDatabase.Email},
            new NpgsqlParameter{Value = userDatabase.Password},
            new NpgsqlParameter{Value = userDatabase.Letters},
            new NpgsqlParameter{Value = userDatabase.ImageUrl},
            new NpgsqlParameter{Value = (object) userDatabase.RoleId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> UpdateUserAsync(string usernameOrEmail, UserDatabase userDatabase)
    {
        string query = "update users set " +
                       "full_name = $3, email = $2, " +
                       "password = $4, letters = $5, " +
                       "image_url = $6, role_id = $7 " +
                       "where username = $1 or email = $2";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = userDatabase.Username},
            new NpgsqlParameter{Value = userDatabase.Email},
            new NpgsqlParameter{Value = userDatabase.FullName},
            new NpgsqlParameter{Value = userDatabase.Password},
            new NpgsqlParameter{Value = userDatabase.Letters},
            new NpgsqlParameter{Value = userDatabase.ImageUrl},
            new NpgsqlParameter{Value = (object) userDatabase.RoleId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public Task<Boolean> DeleteUserAsync(Guid id)
    {
        return DeleteAsync("users", "id", id);
    }

    public Task<Boolean> DeleteUserAsync(string username)
    {
        return DeleteAsync("users", "username", username);
    }
}