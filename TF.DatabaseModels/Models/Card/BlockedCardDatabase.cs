using TF.BlankModels.Models.Card;

namespace TF.DatabaseModels.Models.Card;

public class BlockedCardDatabase
{
    public Guid Id { get; set; }

    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public Guid UserId { get; set; }

    public DateTime StartBlock { get; set; }

    public DateTime EndBlock { get; set; }

    public BlockedCardDatabase()
    {
    }

    public BlockedCardDatabase(Guid id, Guid cardId, string? comment, Guid userId, DateTime startBlock, DateTime endBlock)
    {
        Id = id;
        CardId = cardId;
        Comment = comment;
        UserId = userId;
        StartBlock = startBlock;
        EndBlock = endBlock;
    }

    public BlockedCardDatabase(Guid id, BlockedCardBlank blockedCardBlank, Guid userId)
    {
        Id = id;
        CardId = blockedCardBlank.CardId;
        UserId = userId;
        Comment = blockedCardBlank.Comment;
        StartBlock = blockedCardBlank.StartBlockTimestamp;
        EndBlock = blockedCardBlank.EndBlockTimestamp;
    }
}