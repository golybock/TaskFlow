namespace TF.DatabaseModels.Models.Workspace;

public class WorkspaceTableDatabase
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public Guid CreatedUserId { get; set; }

    public Guid WorkspaceId { get; set; }

    public WorkspaceTableDatabase() { }

    public WorkspaceTableDatabase(Guid id, string name, DateTime createdTimestamp, Guid createdUserId, Guid workspaceId)
    {
        Id = id;
        Name = name;
        CreatedTimestamp = createdTimestamp;
        CreatedUserId = createdUserId;
        WorkspaceId = workspaceId;
    }
}