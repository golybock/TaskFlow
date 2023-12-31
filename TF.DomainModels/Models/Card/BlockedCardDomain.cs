﻿using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.User;
using TF.DomainModels.Models.User;

namespace TF.DomainModels.Models.Card;

public class BlockedCardDomain
{
    public Guid CardId { get; set; }

    public String? Comment { get; set; }

    public UserDomain? BlockedUser { get; set; }

    public DateTime StartBlockTimestamp { get; set; }

    public DateTime EndBlockTimestamp { get; set; }

    public BlockedCardDomain()
    {
    }

    public BlockedCardDomain(Guid cardId, string? comment, UserDomain? blockedUser, DateTime startBlockTimestamp, DateTime endBlockTimestamp)
    {
        CardId = cardId;
        Comment = comment;
        BlockedUser = blockedUser;
        StartBlockTimestamp = startBlockTimestamp;
        EndBlockTimestamp = endBlockTimestamp;
    }

    public BlockedCardDomain(BlockedCardDatabase blockedCardDatabase, UserDatabase? userDatabase)
    {
        CardId = blockedCardDatabase.CardId;
        Comment = blockedCardDatabase.Comment;
        StartBlockTimestamp = blockedCardDatabase.StartBlock;
        EndBlockTimestamp = blockedCardDatabase.EndBlock;

        if (userDatabase != null)
            BlockedUser = new UserDomain(userDatabase);
    }
}