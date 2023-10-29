namespace TF.DatabaseModels.Models.Card;

public class CardDatabase
{
    public Guid Id { get; set; }

    public String Header { get; set; } = null!;

    public String? Description { get; set; }

    public Guid TableColumnId { get; set; }

    public Int32 CardTypeId { get; set; }

    public Guid CreatedUserId { get; set; }

    public Guid PreviousCardId { get; set; }

    public DateTime CreatedTimestamp { get; set; }

    public DateTime Deadline { get; set; }

    public Boolean Deleted { get; set; }
}