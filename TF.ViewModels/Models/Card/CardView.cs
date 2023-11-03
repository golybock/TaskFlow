using TF.DomainModels.Models.Card;
using TF.ViewModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card;

public class CardView
{
    public Guid Id { get; set; }

    public String Header { get; set; } = null!;

    public String? Description { get; set; }

    public String? Path { get; set; }

    public CardTypeView CardType { get; set; } = null!;

    public UserView CreatedUser { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public DateTime Deadline { get; set; }

    public Guid PreviousCardId { get; set; }

    public BlockedCardView? Block { get; set; }

    public IEnumerable<CardCommentView> Comments { get; set; } = new List<CardCommentView>();

    public IEnumerable<TagView> Tags { get; set; } = new List<TagView>();

    public IEnumerable<UserView> Users { get; set; } = new List<UserView>();

    public CardView()
    {
    }

    public CardView(Guid id, string header, string? description, string? path, CardTypeView cardType,
        UserView createdUser, DateTime createdTimestamp, DateTime deadline, Guid previousCardId, BlockedCardView? block)
    {
        Id = id;
        Header = header;
        Description = description;
        Path = path;
        CardType = cardType;
        CreatedUser = createdUser;
        CreatedTimestamp = createdTimestamp;
        Deadline = deadline;
        PreviousCardId = previousCardId;
        Block = block;
    }

    public CardView(CardDomain cardDomain)
    {
        Id = cardDomain.Id;
        Header = cardDomain.Header;
        Description = cardDomain.Description;
        Path = cardDomain.Path;
        CardType = new CardTypeView(cardDomain.CardType);
        CreatedUser = new UserView(cardDomain.CreatedUser);
        CreatedTimestamp = cardDomain.CreatedTimestamp;
        Deadline = cardDomain.Deadline;
        PreviousCardId = cardDomain.PreviousCardId;

        if (cardDomain.Block != null)
            Block = new BlockedCardView(cardDomain.Block);
    }
}