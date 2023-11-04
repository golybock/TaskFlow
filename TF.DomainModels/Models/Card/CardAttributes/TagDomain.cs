using TF.DatabaseModels.Models.Card.CardAttributes;

namespace TF.DomainModels.Models.Card.CardAttributes;

public class TagDomain
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public TagDomain()
    {
    }

    public TagDomain(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public TagDomain(TagDatabase tagDatabase)
    {
        Id = tagDatabase.Id;
        Name = tagDatabase.Name;
        Color = tagDatabase.Color;
    }
}