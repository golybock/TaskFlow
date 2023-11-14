using Npgsql;
using TF.DatabaseModels.Models.Workspace;
using TF.Repositories.Options;

namespace TF.Repositories.Repositories.Workspace;

public class WorkspaceRepository : NpgsqlRepository, IWorkspaceRepository
{
    public WorkspaceRepository(DatabaseOptions databaseOptions) : base(databaseOptions) { }

    public async Task<WorkspaceDatabase?> GetWorkspaceAsync(Guid id)
    {
        string query = "select * from workspace where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = id}
        };

        return await GetAsync<WorkspaceDatabase>(query, parameters);
    }

    public async Task<IEnumerable<WorkspaceDatabase>> GetWorkspacesAsync()
    {
        string query = "select * from workspace";

        return await GetListAsync<WorkspaceDatabase>(query);
    }

    public async Task<WorkspaceTableDatabase?> GetWorkspaceTableAsync(Guid workspaceTableId)
    {
        string query = "select * from workspace_table where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = workspaceTableId}
        };

        return await GetAsync<WorkspaceTableDatabase>(query, parameters);
    }

    public async Task<IEnumerable<WorkspaceTableDatabase>> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        string query = "select * from workspace_table where workspace_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = workspaceId}
        };

        return await GetListAsync<WorkspaceTableDatabase>(query, parameters);
    }

    public async Task<TableColumnDatabase?> GetTableColumnAsync(Guid tableColumnId)
    {
        string query = "select * from table_column where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tableColumnId}
        };

        return await GetAsync<TableColumnDatabase>(query, parameters);
    }

    public async Task<IEnumerable<TableColumnDatabase>> GetTableColumnsAsync(Guid tableId)
    {
        string query = "select * from table_column where workspace_table_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tableId}
        };

        return await GetListAsync<TableColumnDatabase>(query, parameters);
    }

    public async Task<Boolean> CreateWorkspaceAsync(WorkspaceDatabase workspaceDatabase)
    {
        string query = "insert into workspace(id, name, created_user_id)" +
                       "values($1, $2, $3)";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = workspaceDatabase.Id},
            new NpgsqlParameter{Value = workspaceDatabase.Name},
            new NpgsqlParameter{Value = workspaceDatabase.CreatedUserId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> CreateWorkspaceTableAsync(WorkspaceTableDatabase workspaceTableDatabase)
    {
        string query = "insert into workspace_table(id, name, created_user_id, workspace_id)" +
                       "values($1, $2, $3, $4)";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = workspaceTableDatabase.Id},
            new NpgsqlParameter{Value = workspaceTableDatabase.Name},
            new NpgsqlParameter{Value = workspaceTableDatabase.CreatedUserId},
            new NpgsqlParameter{Value = workspaceTableDatabase.WorkspaceId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> CreateTableColumnAsync(TableColumnDatabase tableColumnDatabase)
    {
        string query = "insert into table_column(id, name, workspace_table_id, type_id)" +
                       "values($1, $2, $3, $4)";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = tableColumnDatabase.Id},
            new NpgsqlParameter{Value = tableColumnDatabase.Name},
            new NpgsqlParameter{Value = tableColumnDatabase.WorkspaceTableId},
            new NpgsqlParameter{Value = (object) tableColumnDatabase.TypeId},
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> UpdateWorkspaceAsync(Guid id, WorkspaceDatabase workspaceDatabase)
    {
        string query = "update workspace set " +
                       "name = $2 " +
                       "where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = workspaceDatabase.Id},
            new NpgsqlParameter{Value = workspaceDatabase.Name},
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableDatabase workspaceTableDatabase)
    {
        string query = "update workspace_table set " +
                       "name = $2 " +
                       "where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = workspaceTableDatabase.Id},
            new NpgsqlParameter{Value = workspaceTableDatabase.Name},
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<Boolean> UpdateTableColumnAsync(Guid id, TableColumnDatabase tableColumnDatabase)
    {
        string query = "update table_column set " +
                       "name = $2, type_id = $3 " +
                       "where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter{Value = tableColumnDatabase.Id},
            new NpgsqlParameter{Value = tableColumnDatabase.Name},
            new NpgsqlParameter{Value = (object) tableColumnDatabase.TypeId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public Task<Boolean> DeleteWorkspaceAsync(Guid id)
    {
        return DeleteAsync("workspace", "id", id);
    }

    public Task<Boolean> DeleteWorkspaceTableAsync(Guid id)
    {
        return DeleteAsync("workspace_table", "id", id);
    }

    public Task<Boolean> DeleteTableColumnAsync(Guid id)
    {
        return DeleteAsync("table_column", "id", id);
    }
}