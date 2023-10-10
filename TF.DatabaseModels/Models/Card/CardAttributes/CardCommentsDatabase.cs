namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardCommentsDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public Guid UserId { get; set; }

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }

    public Boolean Deleted { get; set; }
}