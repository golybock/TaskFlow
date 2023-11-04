using System.Collections;
using TF.DatabaseModels.Models.User;
using TF.DatabaseModels.Models.Workspace;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Workspace;

public class WorkspaceDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }

    public UserDomain? User { get; set; }

    public IEnumerable<WorkspaceTableDomain> Tables { get; set; } = new List<WorkspaceTableDomain>();

    public WorkspaceDomain()
    {
    }

    public WorkspaceDomain(Guid id, string name, DateTime createdTimeStamp, UserDomain? user)
    {
        Id = id;
        Name = name;
        CreatedTimeStamp = createdTimeStamp;
        User = user;
    }

    public WorkspaceDomain(Guid id, string name, DateTime createdTimeStamp, UserDatabase? user)
    {
        Id = id;
        Name = name;
        CreatedTimeStamp = createdTimeStamp;

        if (user != null)
            User = new UserDomain(user);
    }

    public WorkspaceDomain(WorkspaceDatabase workspaceDatabase, UserDatabase? user, IEnumerable<WorkspaceTableDomain> tables)
    {
        Id = workspaceDatabase.Id;
        Name = workspaceDatabase.Name;
        CreatedTimeStamp = workspaceDatabase.CreatedTimeStamp;
        Tables = tables;

        if (user != null)
            User = new UserDomain(user);
    }
}