using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Card.CardAttributes;
using TF.DatabaseModels.Models.User;
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

    public Guid PreviousCardId { get; set; }

    public BlockedCardDomain? Block { get; set; }

    public IEnumerable<CardCommentDomain> Comments { get; set; } = new List<CardCommentDomain>();

    public IEnumerable<TagDomain> Tags { get; set; } = new List<TagDomain>();

    public IEnumerable<UserDomain> Users { get; set; } = new List<UserDomain>();

    public CardDomain()
    {
    }

    public CardDomain(Guid id, string header, string? description, string? path, CardTypeDomain cardType,
        UserDomain createdUser, DateTime createdTimestamp, DateTime deadline, Guid previousCardId,
        BlockedCardDomain? block)
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

    public CardDomain(CardDatabase cardDatabase, CardTypeDatabase cardTypeDatabase, UserDatabase userDatabase, BlockedCardDatabase blockedCardDatabase, UserDatabase blockedUser)
    {
        Id = cardDatabase.Id;
        Header = cardDatabase.Header;
        Description = cardDatabase.Description;
        CardType = new CardTypeDomain(cardTypeDatabase);
        CreatedUser = new UserDomain(userDatabase);
        CreatedTimestamp = cardDatabase.CreatedTimestamp;
        Deadline = cardDatabase.Deadline;
        PreviousCardId = cardDatabase.PreviousCardId;
        Block = new BlockedCardDomain(blockedCardDatabase, blockedUser);
    }
}