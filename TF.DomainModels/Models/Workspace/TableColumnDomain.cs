using System.Collections;
using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Workspace;
using TF.DomainModels.Models.Card;
using TF.Tools.Enums;

namespace TF.DomainModels.Models.Workspace;

public class TableColumnDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public ColumnType Type { get; set; }

    public IEnumerable<CardDomain> Cards { get; set; } = new List<CardDomain>();

    public TableColumnDomain()
    {
    }

    public TableColumnDomain(Guid id, string name, ColumnType type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    public TableColumnDomain(Guid id, string name, ColumnType type, IEnumerable<CardDomain> cards)
    {
        Id = id;
        Name = name;
        Type = type;
        Cards = cards;
    }

    public TableColumnDomain(TableColumnDatabase tableColumnDatabase)
    {
        Id = tableColumnDatabase.Id;
        Name = tableColumnDatabase.Name;
        Type = tableColumnDatabase.TypeId;
    }

    public TableColumnDomain(TableColumnDatabase tableColumnDatabase, IEnumerable<CardDomain> cards)
    {
        Id = tableColumnDatabase.Id;
        Name = tableColumnDatabase.Name;
        Type = tableColumnDatabase.TypeId;
        Cards = cards;
    }
}