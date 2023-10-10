using TF.Tools.Enums;
using TF.ViewModels.Models.Card;

namespace TF.ViewModels.Models.Workspace;

public class TableColumnView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public ColumnType Type { get; set; }

    public IEnumerable<CardView> Cards { get; set; } = new List<CardView>();
}