using TF.BlankModels.Models.Workspace;
using TF.ViewModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

public class WorkspaceService : IWorkspaceService
{
    public async Task<IEnumerable<TableColumnView>> GetWorkspaceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WorkspaceView>> GetWorkspacesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<WorkspaceTableView>> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TableColumnView>> GetTableColumnsAsync(Guid tableId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateWorkspaceAsync(WorkspaceBlank workspaceDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateTableColumnAsync(TableColumnBlank tableColumnDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnDatabase, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteWorkspaceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteWorkspaceTableAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteTableColumnAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}