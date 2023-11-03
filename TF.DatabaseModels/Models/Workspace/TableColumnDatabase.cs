using TF.Tools.Enums;

namespace TF.DatabaseModels.Models.Workspace;

public class TableColumnDatabase
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public Guid WorkspaceTableId { get; set; }

    public ColumnType TypeId { get; set; }

    public TableColumnDatabase() { }

    public TableColumnDatabase(Guid id, string name, Guid workspaceTableId, ColumnType typeId)
    {
        Id = id;
        Name = name;
        WorkspaceTableId = workspaceTableId;
        TypeId = typeId;
    }
}