using TF.DomainModels.Models.Card;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card;

public class BlockedCardView
{
    public String? Comment { get; set; }

    public UserView? BlockedUser { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }

    public BlockedCardView()
    {
    }

    public BlockedCardView(string? comment, UserView? blockedUser, DateTime startBlockTimestamp, DateTime endBlockTimestamp)
    {
        Comment = comment;
        BlockedUser = blockedUser;
        StartBlockTimestamp = startBlockTimestamp;
        EndBlockTimestamp = endBlockTimestamp;
    }

    public BlockedCardView(BlockedCardDomain blockedCardDomain)
    {
        Comment = blockedCardDomain.Comment;
        StartBlockTimestamp = blockedCardDomain.StartBlockTimestamp;
        EndBlockTimestamp = blockedCardDomain.EndBlockTimestamp;

        if (blockedCardDomain.BlockedUser != null)
            BlockedUser = new UserView(blockedCardDomain.BlockedUser);
    }
}