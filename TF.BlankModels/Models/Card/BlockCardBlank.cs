﻿namespace TF.BlankModels.Models.Card;

public class BlockCardBlank
{
    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }
}