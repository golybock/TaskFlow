﻿namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class TagDatabase
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public TagDatabase()
    {
    }

    public TagDatabase(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public TagDatabase(string name, string color)
    {
        Name = name;
        Color = color;
    }
}