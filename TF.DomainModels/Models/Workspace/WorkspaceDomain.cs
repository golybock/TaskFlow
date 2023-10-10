using System.Collections;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Workspace;

public class WorkspaceDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }

    public UserDomain? User { get; set; }

    public IEnumerable<WorkspaceTableDomain> Tables { get; set; } = new List<WorkspaceTableDomain>();
}