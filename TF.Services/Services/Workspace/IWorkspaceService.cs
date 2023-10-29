using TF.BlankModels.Models.Workspace;
using TF.ViewModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

public interface IWorkspaceService
{
    public Task<IEnumerable<TableColumnView>> GetWorkspaceAsync(Guid id);

    public Task<IEnumerable<WorkspaceView>> GetWorkspacesAsync();

    public Task<IEnumerable<WorkspaceTableView>> GetWorkspaceTablesAsync(Guid workspaceId);

    public Task<IEnumerable<TableColumnView>> GetTableColumnsAsync(Guid tableId);

    public Task<Boolean> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank, Guid userId);

    public Task<Boolean> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank, Guid userId);

    public Task<Boolean> CreateTableColumnAsync(TableColumnBlank tableColumnBlank, Guid userId);

    public Task<Boolean> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank, Guid userId);

    public Task<Boolean> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank, Guid userId);

    public Task<Boolean> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnBlank, Guid userId);

    public Task<Boolean> DeleteWorkspaceAsync(Guid id);

    public Task<Boolean> DeleteWorkspaceTableAsync(Guid id);

    public Task<Boolean> DeleteTableColumnAsync(Guid id);
}