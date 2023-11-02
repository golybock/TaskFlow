using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> GetWorkspaceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetWorkspacesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetTableColumnsAsync(Guid tableId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateTableColumnAsync(TableColumnBlank tableColumnBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteWorkspaceAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteWorkspaceTableAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteTableColumnAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}