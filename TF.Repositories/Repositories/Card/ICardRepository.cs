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

    public Task<Boolean> CreateCardAsync(CardDatabase cardDatabase);

    public Task<Boolean> UpdateCardAsync(Guid id, CardDatabase cardDatabase);

    public Task<Boolean> DeleteCardAsync(Guid id);

    #endregion

    #region CardComment

    public Task<IEnumerable<CardCommentsDatabase>> GetCardCommentsAsync(Guid cardId);

    public Task<Boolean> CreateCardCommentAsync(CardCommentsDatabase cardCommentsDatabase);

    public Task<Boolean> UpdateCardCommentAsync(Int32 id, CardCommentsDatabase cardCommentsDatabase);

    public Task<Boolean> DeleteCardCommentAsync(Int32 id);

    #endregion

    #region CardTags

    public Task<IEnumerable<TagDatabase>> GetCardTagsAsync(Guid cardId);

    public Task<IEnumerable<TagDatabase>> GetTagsAsync();

    public Task<Boolean> AddTagToCardAsync(Guid cardId, Int32 tagId);

    public Task<Boolean> AddTagsToCardAsync(Guid cardId, IEnumerable<Int32> tagId);

    public Task<Boolean> DeleteCardTagsAsync(Guid cardId);

    public Task<Boolean> DeleteCardTagsAsync(Int32 id);

    #endregion

    #region BlockCard

    public Task<BlockedCardDatabase?> GetBlockedCardAsync(Guid cardId);

    public Task<Boolean> BlockCardAsync(BlockedCardDatabase blockedCardDatabase);

    public Task<Boolean> UnBlockCardAsync(Guid cardId);

    public Task<Boolean> UnBlockCardAsync(Int32 blockedCardId);

    #endregion

    #region CardType

    public Task<CardTypeDatabase?> GetCardTypeAsync(Int32 cardTypeId);

    public Task<IEnumerable<CardTypeDatabase>?> GetCardTypesAsync();

    public Task<Boolean> CreateCardTypeAsync(CardTypeDatabase cardTypeDatabase);

    #endregion

    #region CardUser

    public Task<IEnumerable<UserDatabase>> GetCardUsersAsync(Guid cardId);

    public Task<Boolean> AddCardUserAsync(Guid cardId, Guid userId);

    public Task<Boolean> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds);

    public Task<Boolean> DeleteCardUserAsync(Guid cardId, Guid userId);

    public Task<Boolean> DeleteCardUserAsync(Int32 id);

    #endregion
}