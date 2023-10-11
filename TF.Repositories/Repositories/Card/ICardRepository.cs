using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Card.CardAttributes;
using TF.DatabaseModels.Models.User;

namespace TF.Repositories.Repositories.Card;

public interface ICardRepository
{
    #region Card

    public Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId);

    public Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeId);

    public Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeIds, IEnumerable<Guid> userIds);

    public Task<IEnumerable<CardDatabase>> GetWorkspaceCardsAsync(Guid workspaceId);

    public Task<IEnumerable<CardDatabase>> GetUserCardsAsync(Guid userId);

    public Task<CardDatabase?> GetCardAsync(Guid cardId);

    public Task<Guid> CreateCardAsync(CardDatabase cardDatabase);

    public Task<Guid> UpdateCardAsync(Guid id, CardDatabase cardDatabase);

    public Task<Guid> DeleteCardAsync(Guid id);

    #endregion

    #region CardComment

    public Task<IEnumerable<CardCommentsDatabase>> GetCardCommentsAsync(Guid cardId);

    public Task<Int32> CreateCardCommentAsync(CardCommentsDatabase cardCommentsDatabase);

    public Task<Int32> UpdateCardCommentAsync(Int32 id, CardCommentsDatabase cardCommentsDatabase);

    public Task<Int32> DeleteCardCommentAsync(Int32 id);

    #endregion

    #region CardTags

    public Task<IEnumerable<TagDatabase>> GetCardTagsAsync(Guid cardId);

    public Task<IEnumerable<TagDatabase>> GetTagsAsync();

    public Task<Int32> AddTagToCardAsync(Guid cardId, Int32 tagId);

    public Task<Int32> AddTagsToCardAsync(Guid cardId, IEnumerable<Int32> tagId);

    public Task<Int32> DeleteCardTagsAsync(Guid cardId);

    public Task<Int32> DeleteCardTagsAsync(Int32 id);

    #endregion

    #region BlockCard

    public Task<BlockedCardDatabase?> GetBlockedCardAsync(Guid cardId);

    public Task<Int32> BlockCardAsync(BlockedCardDatabase blockedCardDatabase);

    public Task<Int32> UnBlockCardAsync(Guid cardId);

    public Task<Int32> UnBlockCardAsync(Int32 blockedCardId);

    #endregion

    #region CardType

    public Task<CardTypeDatabase?> GetCardTypeAsync(Int32 cardTypeId);

    public Task<IEnumerable<CardTypeDatabase>?> GetCardTypesAsync();

    public Task<Int32> CreateCardTypeAsync(CardTypeDatabase cardTypeDatabase);

    #endregion

    #region CardUser

    public Task<IEnumerable<UserDatabase>> GetCardUsersAsync(Guid cardId);

    public Task<Int32> AddCardUserAsync(Guid cardId, Guid userId);

    public Task<Int32> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds);

    public Task<Int32> DeleteCardUserAsync(Guid cardId, Guid userId);

    public Task<Int32> DeleteCardUserAsync(Int32 id);

    #endregion
}