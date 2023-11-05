using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Workspace;
using TF.DomainModels.Models.Card;
using TF.DomainModels.Models.Card.CardAttributes;
using TF.DomainModels.Models.User;
using TF.DomainModels.Models.Workspace;
using TF.Repositories.Repositories.Card;
using TF.Repositories.Repositories.Users;
using TF.Repositories.Repositories.Workspace;
using TF.ViewModels.Models.Card;
using TF.ViewModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;
using TF.ViewModels.Models.Workspace;

namespace TF.Services.Services.Workspace;

// todo очень костыльно, но рабоатет
public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICardRepository _cardRepository;

    public WorkspaceService(IWorkspaceRepository workspaceRepository, IUserRepository userRepository, ICardRepository cardRepository)
    {
        _workspaceRepository = workspaceRepository;
        _userRepository = userRepository;
        _cardRepository = cardRepository;
    }

    public async Task<IActionResult> GetWorkspaceAsync(Guid id)
    {
        var workspace = await _workspaceRepository.GetWorkspaceAsync(id);

        if (workspace == null)
            return new NotFoundResult();

        // create and start tasks
        var userTask = _userRepository.GetUserAsync(workspace.CreatedUserId);
        var tablesTask = _workspaceRepository.GetWorkspaceTablesAsync(workspace.Id);

        // await all tasks
        var user = await userTask;
        var tables = await tablesTask;

        // convert models and return result
        WorkspaceDomain workspaceDomain = new WorkspaceDomain(workspace, user, tables);

        WorkspaceView workspaceView = new WorkspaceView(workspaceDomain);

        return new OkObjectResult(workspaceView);
    }

    public async Task<IActionResult> GetWorkspacesAsync()
    {
        var workspaces = await _workspaceRepository.GetWorkspacesAsync();

        if (!workspaces.Any())
            return new NotFoundResult();

        List<WorkspaceView> workspacesView = new List<WorkspaceView>(workspaces.Count());

        foreach (var workspace in workspaces)
        {
            // create and start tasks
            var userTask = _userRepository.GetUserAsync(workspace.CreatedUserId);
            var tablesTask = _workspaceRepository.GetWorkspaceTablesAsync(workspace.Id);

            // await all tasks
            var user = await userTask;
            var tables = await tablesTask;

            // convert models and return result
            WorkspaceDomain workspaceDomain = new WorkspaceDomain(workspace, user, tables);

            WorkspaceView workspaceView = new WorkspaceView(workspaceDomain);

            workspacesView.Add(workspaceView);
        }

        return new OkObjectResult(workspacesView);
    }

    public async Task<IActionResult> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        var tables = await _workspaceRepository.GetWorkspaceTablesAsync(workspaceId);

        if (!tables.Any())
            return new NotFoundResult();

        List<WorkspaceTableDomain> workspaceTableDomains = new List<WorkspaceTableDomain>();

        foreach (var table in tables)
        {
            var createdUser = await _userRepository.GetUserAsync(table.CreatedUserId);

            var columns = GetTableColumnsAsync(table.Id);

            WorkspaceTableDomain workspaceTableDomain = new WorkspaceTableDomain(table, createdUser, );
        }


        return new OkObjectResult(tableViews);
    }

    public async Task<IActionResult> GetTableColumnsAsync(Guid tableId)
    {
        var columns = await _workspaceRepository.GetTableColumnsAsync(tableId);

        if (!columns.Any())
            return new NotFoundResult();

        List<TableColumnView> tableColumnViews = new List<TableColumnView>();

        foreach (var column in columns)
        {
            var cards = await _cardRepository.GetTableCardsAsync(column.WorkspaceTableId);

            var cardViews = cards.Select(async card => await GetCardView(card.Id));

        }

        throw new NotImplementedException();
    }

    #region private get views

    private async Task<List<TableColumnDomain>?> GetTableColumns(Guid tableId)
    {
        var columns = await _workspaceRepository.GetTableColumnsAsync(tableId);

        if (!columns.Any())
            return null;

        List<TableColumnDomain> tableColumnDomains = new List<TableColumnDomain>();

        foreach (var column in columns)
        {
            var cards = await _cardRepository.GetTableCardsAsync(column.WorkspaceTableId);

            var cardViews = cards.Select(async card => await GetCardView(card.Id));

        }
    }

    private async Task<UserDomain?> GetUserView(Guid id)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return null;

        var userDomain = new UserDomain(user);

        return userDomain;
    }

    private async Task<UserDomain?> GetUserView(string usernameOrEmail)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return null;

        var userDomain = new UserDomain(user);

        return userDomain;
    }

    private async Task<CardTypeDomain?> GetCardTypeView(Guid id)
    {
        var cardType = await _cardRepository.GetCardTypeAsync(id);

        if (cardType == null)
            return null;

        var cardTypeDomain = new CardTypeDomain(cardType);

        return cardTypeDomain;
    }

    private async Task<BlockedCardDomain?> GetBlockedCardView(Guid cardId)
    {
        var blockedCard = await _cardRepository.GetBlockedCardAsync(cardId);

        if (blockedCard == null)
            return null;

        var user = await _userRepository.GetUserAsync(blockedCard.UserId);

        var blockedCardDomain = new BlockedCardDomain(blockedCard, user);

        return blockedCardDomain;
    }

    #endregion

    private async Task<CardDomain?> GetCardView(Guid id)
    {
        var card = await _cardRepository.GetCardAsync(id);

        if (card == null)
            return null;

        var cardType = await _cardRepository.GetCardTypeAsync(card.Id);

        var cardUser = await _userRepository.GetUserAsync(card.CreatedUserId);

        // blocked card
        var blockedCard = await _cardRepository.GetBlockedCardAsync(card.Id);
        // if blocked not null, get user
        var blockedCardUser = await _userRepository.GetUserAsync(blockedCard?.UserId ?? Guid.Empty);

        var cardDomain = new CardDomain(card, cardType!, cardUser!, blockedCard, blockedCardUser);

        return cardDomain;
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