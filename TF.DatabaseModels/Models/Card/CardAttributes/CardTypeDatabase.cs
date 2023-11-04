using TF.BlankModels.Models.Card;

namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardTypeDatabase
{
    public Int32 Id { get; set; }

    public String Name { get; set; } = null!;

    public String Color { get; set; } = null!;

    public CardTypeDatabase()
    {
    }

    public CardTypeDatabase(int id, string name, string color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public CardTypeDatabase(string name, string color)
    {
        Name = name;
        Color = color;
    }

    public CardTypeDatabase(CardTypeBlank cardTypeBlank)
    {
        Color = cardTypeBlank.Color;
        Name = cardTypeBlank.Name;
    }
}