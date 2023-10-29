using TF.BlankModels.Models.Workspace;
using TF.Repositories.Repositories.Workspace;
using TF.ViewModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public WorkspaceService(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }

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

    public async Task<bool> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateTableColumnAsync(TableColumnBlank tableColumnBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteWorkspaceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteWorkspaceTableAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteTableColumnAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}