﻿namespace TF.DatabaseModels.Models.Card.CardAttributes;

public class CardUsersDatabase
{
    public Int32 Id { get; set; }

    public Guid CardId { get; set; }

    public Guid UserId { get; set; }
}