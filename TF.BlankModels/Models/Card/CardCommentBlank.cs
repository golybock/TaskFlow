namespace TF.BlankModels.Models.Card;

public class CardCommentBlank
{
    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }
}