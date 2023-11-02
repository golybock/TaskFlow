using Microsoft.AspNetCore.Mvc;
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
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetCardCommentsAsync(Guid cardId)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardTagsAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetBlockedCardAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> BlockCardAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UnBlockCardByIdAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UnBlockCardAsync(Guid blockedCardId)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetCardUsersAsync(Guid cardId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardUserAsync(Guid cardId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteCardUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}