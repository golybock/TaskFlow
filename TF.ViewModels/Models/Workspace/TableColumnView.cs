using TF.DomainModels.Models.Card;
using TF.DomainModels.Models.Workspace;
using TF.Tools.Enums;
using TF.ViewModels.Models.Card;

namespace TF.ViewModels.Models.Workspace;

public class TableColumnView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public ColumnType Type { get; set; }

    public IEnumerable<CardView> Cards { get; set; } = new List<CardView>();

    public TableColumnView()
    {
    }

    public TableColumnView(Guid id, string name, ColumnType type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public TableColumnView(TableColumnDomain tableColumnDomain, IEnumerable<CardView> cards)
    {
        Id = tableColumnDomain.Id;
        Name = tableColumnDomain.Name;
        Type = tableColumnDomain.Type;
        Cards = cards;
    }

    public TableColumnView(TableColumnDomain tableColumnDomain)
    {
        Id = tableColumnDomain.Id;
        Name = tableColumnDomain.Name;
        Type = tableColumnDomain.Type;
        Cards = tableColumnDomain.Cards.Select(card => new CardView(card));
    }
}