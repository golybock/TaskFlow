namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardCommentsDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public Guid UserId { get; set; }

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }

    public Boolean Deleted { get; set; }

    public CardCommentsDatabase()
    {
    }

    public CardCommentsDatabase(int id, Guid cardId, Guid userId, string? comment, string? attachmentUrl, bool deleted)
    {
        Id = id;
        CardId = cardId;
        UserId = userId;
        Comment = comment;
        AttachmentUrl = attachmentUrl;
        Deleted = deleted;
    }
}