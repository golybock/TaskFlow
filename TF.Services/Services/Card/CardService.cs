using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Card;
using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Card.CardAttributes;
using TF.DomainModels.Models.Card;
using TF.DomainModels.Models.Card.CardAttributes;
using TF.DomainModels.Models.User;
using TF.Repositories.Repositories.Card;
using TF.Repositories.Repositories.Users;
using TF.ViewModels.Models.Card;
using TF.ViewModels.Models.Card.CardAttributes;

namespace TF.Services.Services.Card;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IUserRepository _userRepository;

    public CardService(ICardRepository cardRepository, IUserRepository userRepository)
    {
        _cardRepository = cardRepository;
        _userRepository = userRepository;
    }

    public async Task<IActionResult> GetTableCardsAsync(Guid tableId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeIds, IEnumerable<Guid> userIds)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetWorkspaceCardsAsync(Guid workspaceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetUserCardsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateCardAsync(CardBlank cardBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateCardAsync(Guid id, CardBlank cardBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardAsync(Guid id, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateCardAsync(CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateCardAsync(Guid id, CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardAsync(Guid id)
    {
        var res =  await _cardRepository.DeleteCardAsync(id);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetCardCommentsAsync(Guid cardId)
    {
        var cardCommentDomains = await GetCardCommentsDomain(cardId);

        var cardCommentViews = cardCommentDomains.Select(comment => new CardCommentView(comment));

        return new OkObjectResult(cardCommentViews);
    }

    public async Task<IActionResult> CreateCardCommentAsync(CardCommentBlank cardCommentBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentBlank, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardCommentAsync(int id, Guid userId)
    {
        throw new NotImplementedException();
    }

    private async Task<IEnumerable<CardCommentDomain>> GetCardCommentsDomain(Guid cardId)
    {
        var comments = await _cardRepository.GetCardCommentsAsync(cardId);

        List<CardCommentDomain> cardCommentDomains = new List<CardCommentDomain>();

        foreach (var comment in comments)
        {
            var user = await _userRepository.GetUserAsync(comment.UserId);

            var cardCommentDomain = new CardCommentDomain(comment, user!);

            cardCommentDomains.Add(cardCommentDomain);
        }

        return cardCommentDomains;
    }

    public async Task<IActionResult> CreateCardCommentAsync(CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardCommentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetCardTagsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetTagsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddTagToCardAsync(Guid cardId, int tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardTagsAsync(Guid cardId)
    {
        var res = await _cardRepository.DeleteCardTagsAsync(cardId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardTagsAsync(int id)
    {
        var res = await _cardRepository.DeleteCardTagsAsync(id);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetBlockedCardAsync(Guid cardId)
    {
        var blockedCardDomain = await GetBlockedCardDomain(cardId);

        if (blockedCardDomain == null)
            return new NotFoundResult();

        var blockedCardView = new BlockedCardView(blockedCardDomain);

        return new OkObjectResult(blockedCardView);
    }

    private async Task<BlockedCardDomain?> GetBlockedCardDomain(Guid cardId)
    {
        var blockedCardDatabase = await _cardRepository.GetBlockedCardAsync(cardId);

        if (blockedCardDatabase == null)
            return null;

        var user = await _userRepository.GetUserAsync(blockedCardDatabase.UserId);

        var blockedCardDomain = new BlockedCardDomain(blockedCardDatabase, user);

        return blockedCardDomain;
    }

    public async Task<IActionResult> BlockCardAsync(BlockedCardBlank blockedCardBlank, Guid userId)
    {
        var blockCardDatabase = new BlockedCardDatabase(Guid.NewGuid(), blockedCardBlank, userId);

        var res = await _cardRepository.BlockCardAsync(blockCardDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UnBlockCardByIdAsync(Guid cardId)
    {
        var res = await _cardRepository.UnBlockCardByIdAsync(cardId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UnBlockCardAsync(Guid blockedCardId)
    {
        var res = await _cardRepository.UnBlockCardAsync(blockedCardId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetCardTypeAsync(int cardTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetCardTypesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateCardTypeAsync(CardTypeBlank cardTypeBlank)
    {
        var cardDatabase = new CardTypeDatabase(cardTypeBlank);

        var res = await _cardRepository.CreateCardTypeAsync(cardDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetCardUsersAsync(Guid cardId)
    {
        var users = await GetCardUsersDomain(cardId);

        if (!users.Any())
            return new NotFoundResult();

        return new OkObjectResult(users);
    }

    private async Task<IEnumerable<UserDomain>> GetCardUsersDomain(Guid cardId)
    {
        var card = await _cardRepository.GetCardAsync(cardId);

        if (card == null)
            return new List<UserDomain>();

        var users = await _cardRepository.GetCardUsersAsync(cardId);

        var creator = await _userRepository.GetUserAsync(card.CreatedUserId);

        List<UserDomain> userDomains = new List<UserDomain>();

        foreach (var user in users)
        {
            var userDomain = new UserDomain(user);

            userDomains.Add(userDomain);
        }

        userDomains.Add(new UserDomain(creator!));

        return userDomains;
    }

    private async Task<UserDomain?> GetUserDomain(Guid id)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return null;

        var userDomain = new UserDomain(user);

        return userDomain;
    }

    public async Task<IActionResult> AddCardUserAsync(Guid cardId, Guid userId)
    {
        var res = await _cardRepository.AddCardUserAsync(cardId, userId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        var res = await _cardRepository.AddCardUsersAsync(cardId, userIds);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardUserAsync(Guid cardId, Guid userId)
    {
        var res = await _cardRepository.DeleteCardUserAsync(cardId, userId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardUserAsync(int id)
    {
        var res = await _cardRepository.DeleteCardUserAsync(id);

        return res ? new OkResult() : new BadRequestResult();
    }
}