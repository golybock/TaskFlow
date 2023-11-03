using TF.DomainModels.Models.Workspace;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Workspace;

public class WorkspaceTableView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public UserView? User { get; set; }

    public IEnumerable<TableColumnView> Columns { get; set; } = new List<TableColumnView>();

    public WorkspaceTableView()
    {
    }

    public WorkspaceTableView(Guid id, string name, DateTime createdTimestamp, UserView? user)
    {
        Id = id;
        Name = name;
        CreatedTimestamp = createdTimestamp;
        User = user;
    }

    public WorkspaceTableView(WorkspaceTableDomain workspaceTableDomain)
    {
        Id = workspaceTableDomain.Id;
        Name = workspaceTableDomain.Name;
        CreatedTimestamp = workspaceTableDomain.CreatedTimestamp;

        if (workspaceTableDomain.User != null)
            User = new UserView(workspaceTableDomain.User);
    }
}