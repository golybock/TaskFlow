using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Card.CardAttributes;

public class CardCommentDomain
{
    public Int32 Id { get; set; }

    public UserDomain User { get; set; } = null!;

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }
}