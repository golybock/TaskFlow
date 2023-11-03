using TF.DatabaseModels.Models.Workspace;

namespace TF.Repositories.Repositories.Workspace;

public interface IWorkspaceRepository
{
    public Task<WorkspaceDatabase?> GetWorkspaceAsync(Guid id);

    public Task<IEnumerable<WorkspaceDatabase>> GetWorkspacesAsync();

    public Task<IEnumerable<WorkspaceTableDatabase>> GetWorkspaceTablesAsync(Guid workspaceId);

    public Task<IEnumerable<TableColumnDatabase>> GetTableColumnsAsync(Guid tableId);

    public Task<Boolean> CreateWorkspaceAsync(WorkspaceDatabase workspaceDatabase);

    public Task<Boolean> CreateWorkspaceTableAsync(WorkspaceTableDatabase workspaceDatabase);

    public Task<Boolean> CreateTableColumnAsync(TableColumnDatabase tableColumnDatabase);

    public Task<Boolean> UpdateWorkspaceAsync(Guid id, WorkspaceDatabase workspaceDatabase);

    public Task<Boolean> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableDatabase workspaceDatabase);

    public Task<Boolean> UpdateTableColumnAsync(Guid id, TableColumnDatabase tableColumnDatabase);

    public Task<Boolean> DeleteWorkspaceAsync(Guid id);

    public Task<Boolean> DeleteWorkspaceTableAsync(Guid id);

    public Task<Boolean> DeleteTableColumnAsync(Guid id);
}