﻿using TF.ViewModels.Models.Card.CardAttributes;
using TF.ViewModels.Models.User;

namespace TF.ViewModels.Models.Card;

public class CardView
{
    public Guid Id { get; set; }

    public String Header { get; set; } = null!;

    public String? Description { get; set; }

    public String? Path { get; set; }

    public CardTypeView CardType { get; set; } = null!;

    public UserView CreatedUser { get; set; } = null!;

    public DateTime CreatedTimestamp { get; set; }

    public DateTime Deadline { get; set; }

    public BlockedCardView? Block { get; set; }

    public IEnumerable<CardCommentView> Comments { get; set; } = new List<CardCommentView>();

    public IEnumerable<TagView> Tags { get; set; } = new List<TagView>();

    public IEnumerable<UserView> Users { get; set; } = new List<UserView>();
}