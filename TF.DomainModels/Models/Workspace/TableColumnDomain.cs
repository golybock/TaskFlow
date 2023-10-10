using System.Collections;
using TF.DomainModels.Models.Card;
using TF.Tools.Enums;

namespace TF.DomainModels.Models.Workspace;

public class TableColumnDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public ColumnType Type { get; set; }

    public IEnumerable<CardDomain> Cards { get; set; } = new List<CardDomain>();
}