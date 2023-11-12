using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Workspace;
using TF.Services.Services.Workspace;
using ControllerBase = TF.Auth.Controller.ControllerBase;

namespace TF.API.Controllers.Workspace;

[ApiController, Authorize]
[Route("api/[controller]")]
public class WorkspaceController : ControllerBase
{
    private readonly IWorkspaceService _workspaceService;

    public WorkspaceController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetWorkspaceAsync(Guid id)
    {
        return await _workspaceService.GetWorkspaceAsync(id);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetWorkspacesAsync()
    {
        return await _workspaceService.GetWorkspacesAsync();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        return await _workspaceService.GetWorkspaceTablesAsync(workspaceId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTableColumnsAsync(Guid tableId)
    {
        return await _workspaceService.GetTableColumnsAsync(tableId);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank)
    {
        return await _workspaceService.CreateWorkspaceAsync(workspaceBlank, UserId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank)
    {
        return await _workspaceService.CreateWorkspaceTableAsync(workspaceTableBlank, UserId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTableColumnAsync(TableColumnBlank tableColumnBlank)
    {
        return await _workspaceService.CreateTableColumnAsync(tableColumnBlank, UserId);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank)
    {
        return await _workspaceService.UpdateWorkspaceAsync(id, workspaceBlank, UserId);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank)
    {
        return await _workspaceService.UpdateWorkspaceTableAsync(id, workspaceTableBlank, UserId);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateTableColumnAsync(Guid id, TableColumnBlank tableColumnBlank, Guid userId)
    {
        return await _workspaceService.UpdateTableColumnAsync(id, tableColumnBlank, UserId);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteWorkspaceAsync(Guid id)
    {
        return await _workspaceService.DeleteWorkspaceAsync(id);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteWorkspaceTableAsync(Guid id)
    {
        return await _workspaceService.DeleteWorkspaceTableAsync(id);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteTableColumnAsync(Guid id)
    {
        return await _workspaceService.DeleteTableColumnAsync(id);
    }
}