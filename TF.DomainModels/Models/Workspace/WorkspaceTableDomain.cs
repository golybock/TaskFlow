using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Workspace;

public class WorkspaceTableDomain
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public UserDomain? User { get; set; }

    public IEnumerable<TableColumnDomain> Columns { get; set; } = new List<TableColumnDomain>();
}