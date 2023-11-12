namespace TF.API.Controllers.Card;

public class CardTableFilter
{
    public IEnumerable<int>? CardTypeIds { get; set; }

    public IEnumerable<Guid>? UserIds { get; set; }
}