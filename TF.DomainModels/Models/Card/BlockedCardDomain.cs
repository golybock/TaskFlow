using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Card;

public class BlockedCardDomain
{
    public String? Comment { get; set; }

    public UserDomain? BlockedUser { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }
}