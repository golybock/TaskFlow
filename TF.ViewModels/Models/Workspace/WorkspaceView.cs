using TF.DomainModels.Models.Workspace;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Workspace;

public class WorkspaceView
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }

    public UserView? User { get; set; }

    public IEnumerable<WorkspaceTableView> Tables { get; set; } = new List<WorkspaceTableView>();

    public WorkspaceView()
    {
    }

    public WorkspaceView(Guid id, string name, DateTime createdTimeStamp, UserView? user, IEnumerable<WorkspaceTableView> tables)
    {
        Id = id;
        Name = name;
        CreatedTimeStamp = createdTimeStamp;
        User = user;
        Tables = tables;
    }

    public WorkspaceView(WorkspaceDomain workspaceDomain)
    {
        Id = workspaceDomain.Id;
        Name = workspaceDomain.Name;
        CreatedTimeStamp = workspaceDomain.CreatedTimeStamp;

        Tables = workspaceDomain.Tables.Select(table => new WorkspaceTableView(table));

        if (workspaceDomain.User != null)
            User = new UserView(workspaceDomain.User);
    }
}