﻿namespace TF.DatabaseModels.Models.Workspace;

public class WorkspaceDatabase
{
    public Guid Id { get; set; }

    public String Name { get; set; } = null!;

    public DateTime CreatedTimeStamp { get; set; }

    public Guid CreatedUserId { get; set; }

    public WorkspaceDatabase() { }

    public WorkspaceDatabase(Guid id, string name, DateTime createdTimeStamp, Guid createdUserId)
    {
        Id = id;
        Name = name;
        CreatedTimeStamp = createdTimeStamp;
        CreatedUserId = createdUserId;
    }
}