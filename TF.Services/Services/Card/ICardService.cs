using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Card;

namespace TF.Services.Services.Card;

public interface ICardService
{
    #region Card

    public Task<IActionResult> GetTableCardsAsync(Guid tableId);

    public Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeId);

    public Task<IActionResult> GetTableCardsAsync(Guid tableId, IEnumerable<Int32> cardTypeIds, IEnumerable<Guid> userIds);

    public Task<IActionResult> GetWorkspaceCardsAsync(Guid workspaceId);

    public Task<IActionResult> GetUserCardsAsync(Guid userId);

    public Task<IActionResult> GetCardAsync(Guid cardId);

    public Task<IActionResult> CreateCardAsync(CardBlank cardBlank, Guid userId);

    public Task<IActionResult> UpdateCardAsync(Guid id, CardBlank cardBlank, Guid userId);

    public Task<IActionResult> DeleteCardAsync(Guid id, Guid userId);

    #endregion

    #region CardComment

    public Task<IActionResult> GetCardCommentsAsync(Guid cardId);

    public Task<IActionResult> CreateCardCommentAsync(CardCommentBlank cardCommentBlank, Guid userId);

    public Task<IActionResult> UpdateCardCommentAsync(Int32 id, CardCommentBlank cardCommentBlank, Guid userId);

    public Task<IActionResult> DeleteCardCommentAsync(Int32 id, Guid userId);

    #endregion

    #region CardTags

    public Task<IActionResult> GetCardTagsAsync(Guid cardId);

    public Task<IActionResult> GetTagsAsync();

    public Task<IActionResult> AddTagToCardAsync(Guid cardId, Int32 tagId);

    public Task<IActionResult> AddTagsToCardAsync(Guid cardId, IEnumerable<Int32> tagId);

    public Task<IActionResult> DeleteCardTagsAsync(Guid cardId);

    public Task<IActionResult> DeleteCardTagsAsync(Int32 id);

    #endregion

    #region BlockCard

    public Task<IActionResult> GetBlockedCardAsync(Guid cardId);

    public Task<IActionResult> BlockCardAsync(BlockedCardBlank blockedCardBlank, Guid userId);

    public Task<IActionResult> UnBlockCardByIdAsync(Guid cardId);

    public Task<IActionResult> UnBlockCardAsync(Guid blockedCardId);

    #endregion

    #region CardType

    public Task<IActionResult> GetCardTypeAsync(Int32 cardTypeId);

    public Task<IActionResult> GetCardTypesAsync();

    public Task<IActionResult> CreateCardTypeAsync(CardTypeBlank cardTypeBlank);

    #endregion

    #region CardUser

    public Task<IActionResult> GetCardUsersAsync(Guid cardId);

    public Task<IActionResult> AddCardUserAsync(Guid cardId, Guid userId);

    public Task<IActionResult> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds);

    public Task<IActionResult> DeleteCardUserAsync(Guid cardId, Guid userId);

    public Task<IActionResult> DeleteCardUsersAsync(Guid cardId);

    public Task<IActionResult> DeleteCardUserAsync(Int32 id);

    #endregion
}