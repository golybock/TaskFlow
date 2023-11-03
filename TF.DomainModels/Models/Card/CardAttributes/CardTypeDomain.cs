using TF.DatabaseModels.Models.Card.CardAttributes;

namespace TF.DomainModels.Models.Card.CardAttributes;

public class CardTypeDomain
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public CardTypeDomain()
    {
    }

    public CardTypeDomain(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public CardTypeDomain(CardTypeDatabase cardTypeDatabase)
    {
        Id = cardTypeDatabase.Id;
        Name = cardTypeDatabase.Name;
        Color = cardTypeDatabase.Color;
    }
}