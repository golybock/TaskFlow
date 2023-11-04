using TF.DomainModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card.CardAttributes;

public class CardCommentView
{
    public Int32 Id { get; set; }

    public UserView User { get; set; } = null!;

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }

    public CardCommentView()
    {
    }

    public CardCommentView(int id, UserView user, string? comment, string? attachmentUrl)
    {
        Id = id;
        User = user;
        Comment = comment;
        AttachmentUrl = attachmentUrl;
    }

    public CardCommentView(CardCommentDomain cardCommentDomain)
    {
        Id = cardCommentDomain.Id;
        User = new UserView(cardCommentDomain.User);
        Comment = cardCommentDomain.Comment;
        AttachmentUrl = cardCommentDomain.AttachmentUrl;
    }
}