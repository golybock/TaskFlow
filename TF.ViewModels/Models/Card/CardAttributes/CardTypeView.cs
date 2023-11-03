using TF.DomainModels.Models.Card.CardAttributes;

namespace TF.ViewModels.Models.Card.CardAttributes;

public class CardTypeView
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public CardTypeView()
    {
    }

    public CardTypeView(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public CardTypeView(CardTypeDomain cardTypeDomain)
    {
        Id = cardTypeDomain.Id;
        Name = cardTypeDomain.Name;
        Color = cardTypeDomain.Color;
    }
}