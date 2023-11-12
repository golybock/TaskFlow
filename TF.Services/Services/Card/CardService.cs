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
        var cards = await _cardRepository.GetTableCardsAsync(tableId);

        var cardDomains = cards
            .Select(async card => await GetCardDomain(card))
            .Select(res => res.Result);

        var cardViews = cardDomains.Select(c => new CardView(c));

        return new OkObjectResult(cardViews);
    }

    public async Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeIds)
    {
        var cards = await _cardRepository.GetTableCardsAsync(tableId, cardTypeIds);

        var cardDomains = cards
            .Select(async card => await GetCardDomain(card))
            .Select(res => res.Result);

        var cardViews = cardDomains.Select(c => new CardView(c));

        return new OkObjectResult(cardViews);
    }

    public async Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeIds,
        IEnumerable<Guid> userIds)
    {
        var cards = await _cardRepository.GetTableCardsAsync(tableId, cardTypeIds, userIds);

        var cardDomains = cards
            .Select(async card => await GetCardDomain(card))
            .Select(res => res.Result);

        var cardViews = cardDomains.Select(c => new CardView(c));

        return new OkObjectResult(cardViews);
    }

    public async Task<IActionResult> GetWorkspaceCardsAsync(Guid workspaceId)
    {
        var cards = await _cardRepository.GetWorkspaceCardsAsync(workspaceId);

        var cardDomains = cards
            .Select(async card => await GetCardDomain(card))
            .Select(res => res.Result);

        var cardViews = cardDomains.Select(c => new CardView(c));

        return new OkObjectResult(cardViews);
    }

    public async Task<IActionResult> GetUserCardsAsync(Guid userId)
    {
        var cards = await _cardRepository.GetUserCardsAsync(userId);

        var cardDomains = cards
            .Select(async card => await GetCardDomain(card))
            .Select(res => res.Result);

        var cardViews = cardDomains.Select(c => new CardView(c));

        return new OkObjectResult(cardViews);
    }

    public async Task<IActionResult> GetCardAsync(Guid cardId)
    {
        var cardDatabase = await _cardRepository.GetCardAsync(cardId);

        if (cardDatabase == null)
            return new NotFoundResult();

        var cardDomain = await GetCardDomain(cardDatabase);

        var cardView = new CardView(cardDomain);

        return new OkObjectResult(cardView);
    }

    public async Task<IActionResult> CreateCardAsync(CardBlank cardBlank, Guid userId)
    {
        var cardDatabase = new CardDatabase(Guid.NewGuid(), cardBlank, DateTime.UtcNow, userId);

        var res = await _cardRepository.CreateCardAsync(cardDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateCardAsync(Guid id, CardBlank cardBlank, Guid userId)
    {
        var cardDatabase = await _cardRepository.GetCardAsync(id);

        if (cardDatabase == null)
            return new NotFoundResult();

        cardDatabase.Header = cardBlank.Header;
        cardDatabase.Description = cardBlank.Description;
        cardDatabase.CardTypeId = cardBlank.CardTypeId;
        cardDatabase.TableColumnId = cardBlank.TableColumnId;
        cardDatabase.Deadline = cardBlank.Deadline;

        var res = await _cardRepository.UpdateCardAsync(id, cardDatabase);

        // card tags
        await DeleteCardTagsAsync(id);

        await AddTagsToCardAsync(id, cardBlank.CardTags);

        // card users
        await DeleteCardUsersAsync(id);

        await AddCardUsersAsync(id, cardBlank.CardUsers);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardAsync(Guid id, Guid userId)
    {
        var res = await _cardRepository.DeleteCardAsync(id);

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
        var cardCommentsDatabase = new CardCommentsDatabase(cardCommentBlank, userId);

        var res = await _cardRepository.CreateCardCommentAsync(cardCommentsDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    // todo block available for users
    public async Task<IActionResult> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentBlank, Guid userId)
    {
        var cardCommentDatabase = await _cardRepository.GetCardCommentAsync(id);

        if (cardCommentDatabase == null)
            return new NotFoundResult();

        cardCommentDatabase.Comment = cardCommentBlank.Comment;
        cardCommentDatabase.AttachmentUrl = cardCommentBlank.AttachmentUrl;

        var res = await _cardRepository.UpdateCardCommentAsync(id, cardCommentDatabase);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardCommentAsync(int id, Guid userId)
    {
        var res = await _cardRepository.DeleteCardCommentAsync(id);

        return res ? new OkResult() : new BadRequestResult();
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

    public async Task<IActionResult> GetCardTagsAsync(Guid cardId)
    {
        var tags = await GetCardTagsDomain(cardId);

        var tagsView = tags.Select(c => new TagView(c));

        return new OkObjectResult(tagsView);
    }

    public async Task<IActionResult> GetTagsAsync()
    {
        var tags = await GetTagsDomain();

        var tagsView = tags.Select(c => new TagView(c));

        return new OkObjectResult(tagsView);
    }

    private async Task<IEnumerable<TagDomain>> GetCardTagsDomain(Guid cardId)
    {
        var tagsDatabase = await _cardRepository.GetCardTagsAsync(cardId);

        return tagsDatabase.Select(tag => new TagDomain(tag));
    }

    private async Task<IEnumerable<TagDomain>> GetTagsDomain()
    {
        var tagsDatabase = await _cardRepository.GetTagsAsync();

        return tagsDatabase.Select(tag => new TagDomain(tag));
    }

    public async Task<IActionResult> AddTagToCardAsync(Guid cardId, int tagId)
    {
        var card = await _cardRepository.GetCardAsync(cardId);

        if (card == null)
            return new NotFoundResult();

        var res = await _cardRepository.AddTagToCardAsync(cardId, tagId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagIds)
    {
        var res = await _cardRepository.AddTagsToCardAsync(cardId, tagIds);

        return res ? new OkResult() : new BadRequestResult();
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
        var cardType = await GetCardTypeDomain(cardTypeId);

        if (cardType == null)
            return new NotFoundResult();

        var cardTypeView = new CardTypeView(cardType);

        return new OkObjectResult(cardTypeView);
    }

    public async Task<IActionResult> GetCardTypesAsync()
    {
        var cardTypeDomains = await GetCardTypesDomain();

        if (!cardTypeDomains.Any())
            return new NotFoundResult();

        var cardTypeViews = cardTypeDomains.Select(cardTypeDomain => new CardTypeView(cardTypeDomain));

        return new OkObjectResult(cardTypeViews);
    }

    private async Task<CardTypeDomain?> GetCardTypeDomain(int cardTypeId)
    {
        var cardType = await _cardRepository.GetCardTypeAsync(cardTypeId);

        if (cardType == null)
            return null;

        var cardTypeDomain = new CardTypeDomain(cardType);

        return cardTypeDomain;
    }

    private async Task<IEnumerable<CardTypeDomain>> GetCardTypesDomain()
    {
        var cardTypes = await _cardRepository.GetCardTypesAsync();

        var cardTypesDomain = cardTypes.Select(cardType => new CardTypeDomain(cardType));

        return cardTypesDomain;
    }

    public async Task<IActionResult> CreateCardTypeAsync(CardTypeBlank cardTypeBlank)
    {
        var cardDatabase = new CardTypeDatabase(cardTypeBlank);

        var res = await _cardRepository.CreateCardTypeAsync(cardDatabase);

        return res ? new OkResult() : new BadRequestResult();
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
        var cardType = await _cardRepository.GetCardTypeAsync(cardDatabase.CardTypeId);

        var cardUser = await _userRepository.GetUserAsync(cardDatabase.CreatedUserId);

        // blocked card
        var blockedCard = await _cardRepository.GetBlockedCardAsync(cardDatabase.Id);
        // if blocked not null, get user
        var blockedCardUser = await _userRepository.GetUserAsync(blockedCard?.UserId ?? Guid.Empty);

        var cardDomain = new CardDomain(cardDatabase, cardType!, cardUser!, blockedCard, blockedCardUser);

        return cardDomain;
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

    public async Task<IActionResult> DeleteCardUsersAsync(Guid cardId)
    {
        var res = await _cardRepository.DeleteCardUsersAsync(cardId);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteCardUserAsync(int id)
    {
        var res = await _cardRepository.DeleteCardUserAsync(id);

        return res ? new OkResult() : new BadRequestResult();
    }
}