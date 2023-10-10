namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardTagDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public Int32 TagId { get; set; }
}