using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card.CardAttributes;

public class CardCommentView
{
    public Int32 Id { get; set; }

    public UserView User { get; set; } = null!;

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }
}