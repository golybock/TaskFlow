using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Workspace;
using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Workspace;
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

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICardRepository _cardRepository;

    public WorkspaceService(IWorkspaceRepository workspaceRepository, IUserRepository userRepository,
        ICardRepository cardRepository)
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

        var user = await _userRepository.GetUserAsync(workspace.CreatedUserId);
        var tables = await GetWorkspaceTableDomainsAsync(id);

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
            var user = await _userRepository.GetUserAsync(workspace.CreatedUserId);

            var tables = await GetWorkspaceTableDomainsAsync(workspace.Id);

            // convert models and return result
            WorkspaceDomain workspaceDomain = new WorkspaceDomain(workspace, user, tables);

            WorkspaceView workspaceView = new WorkspaceView(workspaceDomain);

            workspacesView.Add(workspaceView);
        }

        return new OkObjectResult(workspacesView);
    }

    public async Task<IActionResult> GetWorkspaceTablesAsync(Guid workspaceId)
    {
        List<WorkspaceTableDomain> workspaceTableDomains = await GetWorkspaceTableDomainsAsync(workspaceId);

        if (!workspaceTableDomains.Any())
            return new NotFoundResult();

        return new OkObjectResult(workspaceTableDomains.Select(c => new WorkspaceTableView(c)));
    }

    public async Task<IActionResult> GetTableColumnsAsync(Guid tableId)
    {
        var columns = await GetTableColumnsDomainAsync(tableId);

        if (!columns.Any())
            return new NotFoundResult();

        return new OkObjectResult(columns);
    }

    public async Task<IActionResult> CreateWorkspaceAsync(WorkspaceBlank workspaceBlank, Guid userId)
    {
        var newId = Guid.NewGuid();

        var workspaceDatabase = new WorkspaceDatabase(newId, workspaceBlank, DateTime.UtcNow, userId);

        var res = await _workspaceRepository.CreateWorkspaceAsync(workspaceDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> CreateWorkspaceTableAsync(WorkspaceTableBlank workspaceTableBlank, Guid userId)
    {
        var newId = Guid.NewGuid();

        var workspaceTableDatabase = new WorkspaceTableDatabase(newId, workspaceTableBlank, DateTime.UtcNow, userId);

        var res = await _workspaceRepository.CreateWorkspaceTableAsync(workspaceTableDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> CreateTableColumnAsync(TableColumnBlank tableColumnBlank, Guid userId)
    {
        var newId = Guid.NewGuid();

        var tableColumnDatabase = new TableColumnDatabase(newId, tableColumnBlank);

        var res = await _workspaceRepository.CreateTableColumnAsync(tableColumnDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateWorkspaceAsync(Guid id, WorkspaceBlank workspaceBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateWorkspaceTableAsync(Guid id, WorkspaceTableBlank workspaceTableBlank,
        Guid userId)
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

    #region private get views

    private async Task<List<TableColumnDomain>?> GetTableColumnsDomainAsync(Guid tableId)
    {
        var columns = await _workspaceRepository.GetTableColumnsAsync(tableId);

        if (!columns.Any())
            return null;

        List<TableColumnDomain> tableColumnDomains = new List<TableColumnDomain>();

        foreach (var column in columns)
        {
            var cards = await _cardRepository.GetTableCardsAsync(column.WorkspaceTableId);

            var cardDomains = cards
                .Select(async card => await GetCardDomain(card))
                .Select(res => res.Result);

            tableColumnDomains.Add(new TableColumnDomain(column, cardDomains));
        }

        return tableColumnDomains;
    }

    private async Task<UserDomain?> GetUserDomain(Guid id)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return null;

        var userDomain = new UserDomain(user);

        return userDomain;
    }

    private async Task<UserDomain?> GetUserDomain(string usernameOrEmail)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return null;

        var userDomain = new UserDomain(user);

        return userDomain;
    }

    private async Task<CardTypeDomain?> GetCardTypeDomain(Guid id)
    {
        var cardType = await _cardRepository.GetCardTypeAsync(id);

        if (cardType == null)
            return null;

        var cardTypeDomain = new CardTypeDomain(cardType);

        return cardTypeDomain;
    }

    private async Task<BlockedCardDomain?> GetBlockedCardDomain(Guid cardId)
    {
        var blockedCard = await _cardRepository.GetBlockedCardAsync(cardId);

        if (blockedCard == null)
            return null;

        var user = await _userRepository.GetUserAsync(blockedCard.UserId);

        var blockedCardDomain = new BlockedCardDomain(blockedCard, user);

        return blockedCardDomain;
    }

    private async Task<CardDomain> GetCardDomain(CardDatabase cardDatabase)
    {
        var cardType = await _cardRepository.GetCardTypeAsync(cardDatabase.Id);

        var cardUser = await _userRepository.GetUserAsync(cardDatabase.CreatedUserId);

        // blocked card
        var blockedCard = await _cardRepository.GetBlockedCardAsync(cardDatabase.Id);
        // if blocked not null, get user
        var blockedCardUser = await _userRepository.GetUserAsync(blockedCard?.UserId ?? Guid.Empty);

        var cardDomain = new CardDomain(cardDatabase, cardType!, cardUser!, blockedCard, blockedCardUser);

        return cardDomain;
    }

    public async Task<List<WorkspaceTableDomain>> GetWorkspaceTableDomainsAsync(Guid workspaceId)
    {
        var tables = await _workspaceRepository.GetWorkspaceTablesAsync(workspaceId);

        List<WorkspaceTableDomain> workspaceTableDomains = new List<WorkspaceTableDomain>();

        foreach (var table in tables)
        {
            var createdUser = await _userRepository.GetUserAsync(table.CreatedUserId);

            var columns = await GetTableColumnsDomainAsync(table.Id);

            WorkspaceTableDomain workspaceTableDomain = new WorkspaceTableDomain(table, createdUser, columns);

            workspaceTableDomains.Add(workspaceTableDomain);
        }

        return workspaceTableDomains;
    }

    private async Task<CardDomain?> GetCardDomain(Guid id)
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

    #endregion
}