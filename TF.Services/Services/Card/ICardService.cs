using TF.BlankModels.Models.Card;
using TF.ViewModels.Models.Card;
using TF.ViewModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Card;

public interface ICardService
{
    #region Card

    public Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId);

    public Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeId);

    public Task<IEnumerable<CardView>> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeIds, IEnumerable<Guid> userIds);

    public Task<IEnumerable<CardView>> GetWorkspaceCardsAsync(Guid workspaceId);

    public Task<IEnumerable<CardView>> GetUserCardsAsync(Guid userId);

    public Task<CardView?> GetCardAsync(Guid cardId);

    public Task<Boolean> CreateCardAsync(CardBlank cardDatabase);

    public Task<Boolean> UpdateCardAsync(Guid id, CardBlank cardDatabase);

    public Task<Boolean> DeleteCardAsync(Guid id);

    #endregion

    #region CardComment

    public Task<IEnumerable<CardCommentView>> GetCardCommentsAsync(Guid cardId);

    public Task<Boolean> CreateCardCommentAsync(CardCommentBlank cardCommentsDatabase);

    public Task<Boolean> UpdateCardCommentAsync(Int32 id, CardCommentBlank cardCommentsDatabase);

    public Task<Boolean> DeleteCardCommentAsync(Int32 id);

    #endregion

    #region CardTags

    public Task<IEnumerable<TagView>> GetCardTagsAsync(Guid cardId);

    public Task<IEnumerable<TagView>> GetTagsAsync();

    public Task<Boolean> AddTagToCardAsync(Guid cardId, Int32 tagId);

    public Task<Boolean> AddTagsToCardAsync(Guid cardId, IEnumerable<Int32> tagId);

    public Task<Boolean> DeleteCardTagsAsync(Guid cardId);

    public Task<Boolean> DeleteCardTagsAsync(Int32 id);

    #endregion

    #region BlockCard

    public Task<BlockedCardView?> GetBlockedCardAsync(Guid cardId);

    public Task<Boolean> BlockCardAsync(Guid cardId, Guid userId);

    public Task<Boolean> UnBlockCardByIdAsync(Guid cardId);

    public Task<Boolean> UnBlockCardAsync(Guid blockedCardId);

    #endregion

    #region CardType

    public Task<CardTypeView?> GetCardTypeAsync(Int32 cardTypeId);

    public Task<IEnumerable<CardTypeView>?> GetCardTypesAsync();

    public Task<Boolean> CreateCardTypeAsync(CardTypeBlank cardTypeBlank);

    #endregion

    #region CardUser

    public Task<IEnumerable<UserView>> GetCardUsersAsync(Guid cardId);

    public Task<Boolean> AddCardUserAsync(Guid cardId, Guid userId);

    public Task<Boolean> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds);

    public Task<Boolean> DeleteCardUserAsync(Guid cardId, Guid userId);

    public Task<Boolean> DeleteCardUserAsync(Int32 id);

    #endregion
}