using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Workspace;

public class WorkspaceView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }

    public UserView? User { get; set; }

    public IEnumerable<WorkspaceTableView> Tables { get; set; } = new List<WorkspaceTableView>();
}