using TF.DatabaseModels.Models.User;
using TF.DatabaseModels.Models.Workspace;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Workspace;

public class WorkspaceTableDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public Guid WorkspaceId { get; set; }

    public UserDomain? User { get; set; }

    public IEnumerable<TableColumnDomain> Columns { get; set; } = new List<TableColumnDomain>();

    public WorkspaceTableDomain()
    {
    }

    public WorkspaceTableDomain(Guid id, string name, DateTime createdTimestamp, Guid workspaceId, UserDomain? user)
    {
        Id = id;
        Name = name;
        CreatedTimestamp = createdTimestamp;
        WorkspaceId = workspaceId;
        User = user;
    }

    public WorkspaceTableDomain(WorkspaceTableDatabase workspaceTableDatabase, UserDatabase? user, IEnumerable<TableColumnDomain> columns)
    {
        Id = workspaceTableDatabase.Id;
        Name = workspaceTableDatabase.Name;
        CreatedTimestamp = workspaceTableDatabase.CreatedTimestamp;
        WorkspaceId = workspaceTableDatabase.WorkspaceId;
        Columns = columns;

        if (user != null)
            User = new UserDomain(user);
    }
}