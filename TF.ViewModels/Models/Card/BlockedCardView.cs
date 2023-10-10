using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card;

public class BlockedCardView
{
    public String? Comment { get; set; }

    public UserView? BlockedUser { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }
}