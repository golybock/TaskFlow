using TF.BlankModels.Models.Card;
using TF.Repositories.Repositories.Card;
using TF.ViewModels.Models.Card;
using TF.ViewModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Card;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeIds, IEnumerable<Guid> userIds)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardView>> GetWorkspaceCardsAsync(Guid workspaceId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardView>> GetUserCardsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CardView?> GetCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateCardAsync(CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> UpdateCardAsync(Guid id, CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> DeleteCardAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardCommentView>> GetCardCommentsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateCardCommentAsync(CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCardCommentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TagView>> GetCardTagsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TagView>> GetTagsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddTagToCardAsync(Guid cardId, int tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCardTagsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCardTagsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BlockedCardView?> GetBlockedCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> BlockCardAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UnBlockCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UnBlockCardAsync(int blockedCardId)
    {
        throw new NotImplementedException();
    }

    public async Task<CardTypeView?> GetCardTypeAsync(int cardTypeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardTypeView>?> GetCardTypesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserView>> GetCardUsersAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteCardUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}