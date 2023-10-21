using Npgsql;

namespace TF.Repositories.Reader;

public interface IReader<T>
{
    public static abstract Task<T?> ReadAsync(NpgsqlDataReader reader);

    public static abstract Task<IEnumerable<T>> ReadListAsync(NpgsqlDataReader reader);
}