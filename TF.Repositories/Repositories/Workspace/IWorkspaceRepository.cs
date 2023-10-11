using TF.DatabaseModels.Models.Workspace;

namespace TF.Repositories.Repositories.Workspace;

public interface IWorkspaceRepository
{
    public Task<IEnumerable<WorkspaceDatabase>> GetWorkspaceAsync(Guid id);

    public Task<IEnumerable<WorkspaceDatabase>> GetWorkspacesAsync();

    public Task<IEnumerable<WorkspaceTableDatabase>> GetWorkspaceTablesAsync(Guid workspaceId);

    public Task<IEnumerable<TableColumnDatabase>> GetTableColumnsAsync(Guid tableId);

    public Task<Guid> CreateWorkspaceAsync(WorkspaceDatabase workspaceDatabase);

    public Task<Guid> CreateWorkspaceTableAsync(WorkspaceTableDatabase workspaceDatabase);

    public Task<Guid> CreateTableColumnAsync(TableColumnDatabase tableColumnDatabase);

    public Task<Int32> UpdateWorkspaceAsync(Guid id, WorkspaceDatabase workspaceDatabase);

    public Task<Int32> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableDatabase workspaceDatabase);

    public Task<Int32> UpdateTableColumnAsync(Guid id, TableColumnDatabase tableColumnDatabase);

    public Task<Int32> DeleteWorkspaceAsync(Guid id);

    public Task<Int32> DeleteWorkspaceTableAsync(Guid id);

    public Task<Int32> DeleteTableColumnAsync(Guid id);
}