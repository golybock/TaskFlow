using TF.DatabaseModels.Models.Card.CardAttributes;
using TF.DatabaseModels.Models.User;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Card.CardAttributes;

public class CardCommentDomain
{
    public Int32 Id { get; set; }

    public UserDomain User { get; set; } = null!;

    public String? Comment { get; set; }

    public String? AttachmentUrl { get; set; }

    public Boolean Deleted { get; set; }

    public CardCommentDomain()
    {
    }

    public CardCommentDomain(int id, UserDomain user, string? comment, string? attachmentUrl)
    {
        Id = id;
        User = user;
        Comment = comment;
        AttachmentUrl = attachmentUrl;
    }

    public CardCommentDomain(CardCommentsDatabase cardCommentsDatabase, UserDatabase userDatabase)
    {
        Id = cardCommentsDatabase.Id;
        User = new UserDomain(userDatabase);
        Comment = cardCommentsDatabase.Comment;
        AttachmentUrl = cardCommentsDatabase.AttachmentUrl;
        Deleted = cardCommentsDatabase.Deleted;
    }
}