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
}