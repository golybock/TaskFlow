using System.Collections;
using Npgsql;

namespace TF.Repositories.Readers;

public interface IReader<T>
{
    public static abstract Task<T?> ReadAsync(NpgsqlDataReader reader);

    public static abstract Task<IEnumerable> ReadListAsync(NpgsqlDataReader reader);
}