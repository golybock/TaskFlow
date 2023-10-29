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

    public async Task<bool> CreateCardAsync(CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCardAsync(Guid id, CardBlank cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CardCommentView>> GetCardCommentsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateCardCommentAsync(CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardCommentAsync(int id)
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

    public async Task<bool> AddTagToCardAsync(Guid cardId, int tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardTagsAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardTagsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BlockedCardView?> GetBlockedCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> BlockCardAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UnBlockCardByIdAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UnBlockCardAsync(Guid blockedCardId)
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

    public async Task<bool> CreateCardTypeAsync(CardTypeBlank cardTypeBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserView>> GetCardUsersAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}