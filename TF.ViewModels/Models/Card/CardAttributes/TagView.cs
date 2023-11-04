using TF.DomainModels.Models.Card.CardAttributes;

namespace TF.ViewModels.Models.Card.CardAttributes;

public class TagView
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public TagView()
    {
    }

    public TagView(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public TagView(TagDomain tagDomain)
    {
        Id = tagDomain.Id;
        Name = tagDomain.Name;
        Color = tagDomain.Color;
    }
}