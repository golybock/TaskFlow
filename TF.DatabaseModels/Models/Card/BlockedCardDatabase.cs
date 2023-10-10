namespace TF.DatabaseModels.Models.Card;

public class BlockedCardDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public Guid BlockedUserId { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }
}