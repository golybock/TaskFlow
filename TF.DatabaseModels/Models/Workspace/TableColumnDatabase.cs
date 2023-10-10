using TF.Tools.Enums;

namespace TF.DatabaseModels.Models.Workspace;

public class TableColumnDatabase
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public Guid WorkspaceTableId { get; set; }

    public ColumnType TypeId { get; set; }
}