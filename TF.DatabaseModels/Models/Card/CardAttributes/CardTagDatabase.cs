namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardTagDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public Int32 TagId { get; set; }

    public CardTagDatabase()
    {
    }

    public CardTagDatabase(int id, Guid cardId, int tagId)
    {
        Id = id;
        CardId = cardId;
        TagId = tagId;
    }

    public CardTagDatabase(Guid cardId, int tagId)
    {
        CardId = cardId;
        TagId = tagId;
    }
}