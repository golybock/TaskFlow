using Npgsql;

namespace TF.Repositories.Repositories;

public class RepositoryBase
{
    private readonly string? _connectionString;

    protected RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    protected async Task<int> DeleteAsync(string table, string column, object param)
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = $"delete from {table} where {column} = $1";

            await using var cmd = new NpgsqlCommand(query, connection)
            {
                Parameters =
                {
                    new NpgsqlParameter { Value = param }
                }
            };

            return await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    protected async Task<int> DeleteCascadeAsync(string table, string column, object param)
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = $"delete from {table} where {column} = $1 cascade";

            await using var cmd = new NpgsqlCommand(query, connection)
            {
                Parameters =
                {
                    new NpgsqlParameter { Value = param }
                }
            };

            return await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return -1;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}