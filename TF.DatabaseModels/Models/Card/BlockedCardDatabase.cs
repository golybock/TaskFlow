namespace TF.DatabaseModels.Models.Card;

public class BlockedCardDatabase
{
    public Guid Id { get; set; }

    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public Guid UserId { get; set; }

    public DateTime StartBlock { get; set; }

    public DateTime EndBlock { get; set; }
}