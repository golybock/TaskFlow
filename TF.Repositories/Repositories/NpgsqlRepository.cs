﻿using Npgsql;
using TF.Repositories.Reader;

namespace TF.Repositories.Repositories;

public abstract class NpgsqlRepository
{
    private readonly string? _connectionString;

    protected NpgsqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected NpgsqlConnection GetConnection() =>
        new NpgsqlConnection(_connectionString);

    protected async Task<T?> GetAsync<T>(string query, NpgsqlParameter[] parameters) where T : new()
    {
        var connection = GetConnection();

        try
        {
            await connection.OpenAsync();

            await using var cmd = new NpgsqlCommand(query, connection);

            cmd.Parameters.AddRange(parameters);

            await using var reader = await cmd.ExecuteReaderAsync();

            return await Reader<T>.ReadAsync(reader);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    protected async Task<IEnumerable<T>> GetListAsync<T>(string query, NpgsqlParameter[] parameters) where T : new()
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            await using var cmd = new NpgsqlCommand(query, connection);

            cmd.Parameters.AddRange(parameters);

            var reader = await cmd.ExecuteReaderAsync();

            return await Reader<T>.ReadListAsync(reader);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
                    new NpgsqlParameter {Value = param}
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
                    new NpgsqlParameter {Value = param}
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