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

    public Task<Guid> CreateCardAsync(CardBlank cardDatabase);

    public Task<Guid> UpdateCardAsync(Guid id, CardBlank cardDatabase);

    public Task<Guid> DeleteCardAsync(Guid id);

    #endregion

    #region CardComment

    public Task<IEnumerable<CardCommentView>> GetCardCommentsAsync(Guid cardId);

    public Task<Int32> CreateCardCommentAsync(CardCommentBlank cardCommentsDatabase);

    public Task<Int32> UpdateCardCommentAsync(Int32 id, CardCommentBlank cardCommentsDatabase);

    public Task<Int32> DeleteCardCommentAsync(Int32 id);

    #endregion

    #region CardTags

    public Task<IEnumerable<TagView>> GetCardTagsAsync(Guid cardId);

    public Task<IEnumerable<TagView>> GetTagsAsync();

    public Task<Int32> AddTagToCardAsync(Guid cardId, Int32 tagId);

    public Task<Int32> AddTagsToCardAsync(Guid cardId, IEnumerable<Int32> tagId);

    public Task<Int32> DeleteCardTagsAsync(Guid cardId);

    public Task<Int32> DeleteCardTagsAsync(Int32 id);

    #endregion

    #region BlockCard

    public Task<BlockedCardView?> GetBlockedCardAsync(Guid cardId);

    public Task<Int32> BlockCardAsync(Guid cardId, Guid userId);

    public Task<Int32> UnBlockCardAsync(Guid cardId);

    public Task<Int32> UnBlockCardAsync(Int32 blockedCardId);

    #endregion

    #region CardType

    public Task<CardTypeView?> GetCardTypeAsync(Int32 cardTypeId);

    public Task<IEnumerable<CardTypeView>?> GetCardTypesAsync();

    #endregion

    #region CardUser

    public Task<IEnumerable<UserView>> GetCardUsersAsync(Guid cardId);

    public Task<Int32> AddCardUserAsync(Guid cardId, Guid userId);

    public Task<Int32> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds);

    public Task<Int32> DeleteCardUserAsync(Guid cardId, Guid userId);

    public Task<Int32> DeleteCardUserAsync(Int32 id);

    #endregion
}