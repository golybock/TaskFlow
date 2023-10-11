namespace TF.BlankModels.Models.Card;

public class CardBlank
{
    public String Header { get; set; } = null!;

    public String? Description { get; set; }

    public Guid TableColumnId { get; set; }

    public Int32 CardTypeId { get; set; }

    public DateTime Deadline { get; set; }

    public IEnumerable<Int32> CardTags { get; set; } = new List<Int32>();

    public IEnumerable<Guid> CardUsers { get; set; } = new List<Guid>();
}