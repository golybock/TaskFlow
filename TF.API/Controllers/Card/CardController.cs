using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.Card;
using TF.Services.Services.Card;
using ControllerBase = TF.Auth.Controller.ControllerBase;

namespace TF.API.Controllers.Card;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CardController: ControllerBase
{
    // todo далеко не все методы нужно - почистить от ненужных
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTableCardsAsync(Guid tableId, CardTableFilter cardTableFilter)
    {
        if (cardTableFilter.CardTypeIds == null && cardTableFilter.UserIds == null)
        {
            return await _cardService.GetUserCardsAsync(tableId);
        }

        if (cardTableFilter.UserIds == null && cardTableFilter.CardTypeIds != null)
        {
            return await _cardService.GetTableCardsAsync(tableId, cardTableFilter.CardTypeIds);
        }

        return await _cardService.GetTableCardsAsync(tableId, cardTableFilter.CardTypeIds!, cardTableFilter.UserIds!);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetWorkspaceCardsAsync(Guid workspaceId)
    {
        return await _cardService.GetWorkspaceCardsAsync(workspaceId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUserCardsAsync(Guid? userId)
    {
        if (userId == null)
            return await _cardService.GetUserCardsAsync(UserId);

        return await _cardService.GetUserCardsAsync(userId.Value);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardAsync(Guid cardId)
    {
        return await _cardService.GetCardAsync(cardId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCardAsync(CardBlank cardBlank)
    {
        return await _cardService.CreateCardAsync(cardBlank, UserId);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCardAsync(Guid id, CardBlank cardBlank)
    {
        return await _cardService.UpdateCardAsync(id, cardBlank, UserId);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCardAsync(Guid id)
    {
        return await _cardService.DeleteCardAsync(id, UserId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardCommentsAsync(Guid cardId)
    {
        return await _cardService.GetCardCommentsAsync(cardId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCardCommentAsync(CardCommentBlank cardCommentBlank)
    {
        return await _cardService.CreateCardCommentAsync(cardCommentBlank, UserId);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCardCommentAsync(int id, CardCommentBlank cardCommentBlank)
    {
        return await _cardService.UpdateCardCommentAsync(id, cardCommentBlank, UserId);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCardCommentAsync(int id)
    {
        return await _cardService.DeleteCardCommentAsync(id, UserId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardTagsAsync(Guid cardId)
    {
        return await _cardService.GetCardTagsAsync(cardId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTagsAsync()
    {
        return await _cardService.GetTagsAsync();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTagToCardAsync(Guid cardId, int tagId)
    {
        return await _cardService.AddTagToCardAsync(cardId, tagId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagIds)
    {
        return await _cardService.AddTagsToCardAsync(cardId, tagIds);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCardTagsAsync(Guid? cardId, Int32? cardTagId)
    {
        if(cardId != null)
            return await _cardService.DeleteCardTagsAsync(cardId.Value);

        if (cardTagId != null)
            return await _cardService.DeleteCardTagsAsync(cardTagId.Value);

        return BadRequest();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetBlockedCardAsync(Guid cardId)
    {
        return await _cardService.GetBlockedCardAsync(cardId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> BlockCardAsync(BlockedCardBlank blockedCardBlank)
    {
        return await _cardService.BlockCardAsync(blockedCardBlank, UserId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UnBlockCardByIdAsync(Guid cardId)
    {
        return await _cardService.UnBlockCardByIdAsync(cardId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UnBlockCardAsync(Guid blockedCardId)
    {
        return await _cardService.UnBlockCardAsync(blockedCardId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardTypeAsync(int cardTypeId)
    {
        return await _cardService.GetCardTypeAsync(cardTypeId);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardTypesAsync()
    {
        return await _cardService.GetCardTypesAsync();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCardTypeAsync(CardTypeBlank cardTypeBlank)
    {
        return await _cardService.CreateCardTypeAsync(cardTypeBlank);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCardUsersAsync(Guid cardId)
    {
        return await _cardService.GetCardUsersAsync(cardId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddCardUserAsync(Guid cardId, Guid userId)
    {
        return await _cardService.AddCardUserAsync(cardId, userId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        return await _cardService.AddCardUsersAsync(cardId, userIds);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCardUserAsync(Guid cardId)
    {
        return await _cardService.DeleteCardUserAsync(cardId, UserId);
    }

    // [HttpDelete("[action]")]
    // public async Task<IActionResult> DeleteCardUserAsync(int id)
    // {
    //     return await _cardService.DeleteCardUserAsync(id);
    // }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCardUsersAsync(Guid cardId)
    {
        return await _cardService.DeleteCardUsersAsync(cardId);
    }
}