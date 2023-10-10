using TF.Tools.Enums;

namespace TF.BlankModels.Models.Workspace;

public class TableColumnBlank
{
    public String Name { get; set; } = null!;

    public Guid WorkspaceTableId { get; set; }

    public ColumnType TypeId { get; set; }
}