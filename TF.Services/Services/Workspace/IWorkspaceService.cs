using TF.BlankModels.Models.Workspace;
using TF.ViewModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

public interface IWorkspaceService
{
    public Task<IEnumerable<TableColumnView>> GetWorkspaceAsync(Guid id);

    public Task<IEnumerable<WorkspaceView>> GetWorkspacesAsync();

    public Task<IEnumerable<WorkspaceTableView>> GetWorkspaceTablesAsync(Guid workspaceId);

    public Task<IEnumerable<TableColumnView>> GetTableColumnsAsync(Guid tableId);

    public Task<Guid> CreateWorkspaceAsync(WorkspaceBlank workspaceDatabase, Guid userId);

    public Task<Guid> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceDatabase, Guid userId);

    public Task<Guid> CreateTableColumnAsync(TableColumnBlank tableColumnDatabase, Guid userId);

    public Task<Int32> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceDatabase, Guid userId);

    public Task<Int32> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceDatabase, Guid userId);

    public Task<Int32> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnDatabase, Guid userId);

    public Task<Int32> DeleteWorkspaceAsync(Guid id);

    public Task<Int32> DeleteWorkspaceTableAsync(Guid id);

    public Task<Int32> DeleteTableColumnAsync(Guid id);
}