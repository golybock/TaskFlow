using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Workspace;

public class WorkspaceTableView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public UserView? User { get; set; }

    public IEnumerable<TableColumnView> Columns { get; set; } = new List<TableColumnView>();
}