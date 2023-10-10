using TF.DomainModels.Models.Card.CardAttributes;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Card;

public class CardDomain
{
    public Guid Id { get; set; }

    public String Header { get; set; } = null!;

    public String? Description { get; set; }

    public String? Path { get; set; }

    public CardTypeDomain CardType { get; set; } = null!;

    public UserDomain CreatedUser { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public DateTime Deadline { get; set; }

    public BlockedCardDomain? Block { get; set; }

    public IEnumerable<CardCommentDomain> Comments { get; set; } = new List<CardCommentDomain>();

    public IEnumerable<TagDomain> Tags { get; set; } = new List<TagDomain>();

    public IEnumerable<UserDomain> Users { get; set; } = new List<UserDomain>();
}