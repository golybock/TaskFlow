using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

public interface IWorkspaceService
{
    public Task<IActionResult> GetWorkspaceAsync(Guid id);

    public Task<IActionResult> GetWorkspacesAsync();

    public Task<IActionResult> GetWorkspaceTablesAsync(Guid workspaceId);

    public Task<IActionResult> GetTableColumnsAsync(Guid tableId);

    public Task<IActionResult> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank, Guid userId);

    public Task<IActionResult> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank, Guid userId);

    public Task<IActionResult> CreateTableColumnAsync(TableColumnBlank tableColumnBlank, Guid userId);

    public Task<IActionResult> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank, Guid userId);

    public Task<IActionResult> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank, Guid userId);

    public Task<IActionResult> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnBlank, Guid userId);

    public Task<IActionResult> DeleteWorkspaceAsync(Guid id);

    public Task<IActionResult> DeleteWorkspaceTableAsync(Guid id);

    public Task<IActionResult> DeleteTableColumnAsync(Guid id);
}