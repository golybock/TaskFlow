using Npgsql;
using TF.DatabaseModels.Models.Card;
using TF.DatabaseModels.Models.Card.CardAttributes;
using TF.DatabaseModels.Models.User;

namespace TF.Repositories.Repositories.Card;

public class CardRepository : NpgsqlRepository, ICardRepository
{
    public CardRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId)
    {
        string query = "select c.* from card c " +
                       "join table_column tc on tc.id = c.table_column_id " +
                       "join public.workspace_table wt on wt.id = tc.workspace_table_id " +
                       "where wt.id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tableId}
        };

        return await GetListAsync<CardDatabase>(query, parameters);
    }

    public async Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeId)
    {
        string query = "select c.* from card c " +
                       "join table_column tc on tc.id = c.table_column_id " +
                       "join workspace_table wt on wt.id = tc.workspace_table_id " +
                       "where wt.id = $1 and " +
                       "c.card_type_id = any($2)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tableId},
            new NpgsqlParameter {Value = cardTypeId}
        };

        return await GetListAsync<CardDatabase>(query, parameters);
    }

    public async Task<IEnumerable<CardDatabase>> GetTableCardsAsync(Guid tableId, IEnumerable<int> cardTypeIds,
        IEnumerable<Guid> userIds)
    {
        string query = "select c.* from card c " +
                       "join table_column tc on tc.id = c.table_column_id " +
                       "join workspace_table wt on wt.id = tc.workspace_table_id " +
                       "join card_users cu on c.id = cu.card_id " +
                       "where wt.id = $1 and " +
                       "c.card_type_id = any($2) and " +
                       "cu.user_id = any($3)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tableId},
            new NpgsqlParameter {Value = cardTypeIds},
            new NpgsqlParameter {Value = userIds},
        };

        return await GetListAsync<CardDatabase>(query, parameters);
    }

    public async Task<IEnumerable<CardDatabase>> GetWorkspaceCardsAsync(Guid workspaceId)
    {
        string query = "select c.* from card c " +
                       "join table_column tc on tc.id = c.table_column_id " +
                       "join workspace_table wt on wt.id = tc.workspace_table_id " +
                       "join public.workspace w on w.id = wt.workspace_id " +
                       "where w.id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = workspaceId}
        };

        return await GetListAsync<CardDatabase>(query, parameters);
    }

    public async Task<IEnumerable<CardDatabase>> GetUserCardsAsync(Guid userId)
    {
        string query = "select c.* from card c " +
                       "join card_users cu on c.id = cu.card_id " +
                       "where c.created_user_id = $1 or " +
                       "cu.user_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = userId}
        };

        return await GetListAsync<CardDatabase>(query, parameters);
    }

    public async Task<CardDatabase?> GetCardAsync(Guid cardId)
    {
        string query = "select c.* from card c " +
                       "where c.id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await GetAsync<CardDatabase>(query, parameters);
    }

    public async Task<bool> CreateCardAsync(CardDatabase cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCardAsync(Guid id, CardDatabase cardDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardAsync(Guid id)
    {
        string query = "delete from card where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = id}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<CardCommentsDatabase>> GetCardCommentsAsync(Guid cardId)
    {
        string query = "select cc.* from card_comments cc " +
                       "join card c on c.id = cc.card_id " +
                       "where c.id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await GetListAsync<CardCommentsDatabase>(query, parameters);
    }

    public async Task<bool> CreateCardCommentAsync(CardCommentsDatabase cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateCardCommentAsync(int id, CardCommentsDatabase cardCommentsDatabase)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteCardCommentAsync(int id)
    {
        string query = "delete from card_comments where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = id}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<TagDatabase>> GetCardTagsAsync(Guid cardId)
    {
        string query = "select ct.* from card_tag ct " +
                       "join card c on c.id = ct.card_id " +
                       "where c.id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await GetListAsync<TagDatabase>(query, parameters);
    }

    public async Task<IEnumerable<TagDatabase>> GetTagsAsync()
    {
        string query = "select * from card_tag";

        return await GetListAsync<TagDatabase>(query);
    }

    public async Task<bool> AddTagToCardAsync(Guid cardId, int tagId)
    {
        string query = "insert into card_tag(card_id, tag_id) values ($1, $2)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId},
            new NpgsqlParameter {Value = tagId},
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<bool> AddTagsToCardAsync(Guid cardId, IEnumerable<int> tagIds)
    {
        var result = true;

        foreach (var tagId in tagIds)
        {
            var res = await AddTagToCardAsync(cardId, tagId);

            if (res == false)
            {
                result = false;
            }
        }

        return result;
    }

    public async Task<bool> DeleteCardTagsAsync(Guid cardId)
    {
        string query = "delete from card_tag where card_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<bool> DeleteCardTagsAsync(int tagId)
    {
        string query = "delete from card_tag where tag_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = tagId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<BlockedCardDatabase?> GetBlockedCardAsync(Guid cardId)
    {
        string query = "select * from blocked_card " +
                       "where card_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await GetAsync<BlockedCardDatabase>(query, parameters);
    }

    public async Task<bool> BlockCardAsync(BlockedCardDatabase blockedCardDatabase)
    {
        string query = "insert into blocked_card(card_id, comment, blocked_user_id, end_block_timestamp) " +
                       "values ($1, $2, $3, $4)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = blockedCardDatabase.CardId},
            new NpgsqlParameter {Value = blockedCardDatabase.Comment},
            new NpgsqlParameter {Value = blockedCardDatabase.BlockedUserId},
            new NpgsqlParameter {Value = blockedCardDatabase.EndBlockTimestamp}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<bool> UnBlockCardAsync(Guid cardId)
    {
        string query = "update blocked_card set end_block_timestamp = $2 " +
                       "where card_id = $1";

        // todo очень плохо, нужно передавать дату как параметр
        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId},
            new NpgsqlParameter {Value = DateTime.UtcNow},
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<bool> UnBlockCardAsync(int blockedCardId)
    {
        string query = "update blocked_card set end_block_timestamp = $2 " +
                       "where id = $1";

        // todo очень плохо, нужно передавать дату как параметр
        var parameters = new[]
        {
            new NpgsqlParameter {Value = blockedCardId},
            new NpgsqlParameter {Value = DateTime.UtcNow}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<CardTypeDatabase?> GetCardTypeAsync(int cardTypeId)
    {
        string query = "select * from card_type " +
                       "where id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardTypeId}
        };

        return await GetAsync<CardTypeDatabase>(query, parameters);
    }

    public async Task<IEnumerable<CardTypeDatabase>?> GetCardTypesAsync()
    {
        string query = "select * from card_type ";

        return await GetListAsync<CardTypeDatabase>(query);
    }

    // todo maybe return id
    public async Task<bool> CreateCardTypeAsync(CardTypeDatabase cardTypeDatabase)
    {
        string query = "insert into card_type(name, color) values ($1, $2)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardTypeDatabase.Name},
            new NpgsqlParameter {Value = cardTypeDatabase. Color}
        };

        return await ExecuteAsync(query, parameters);
    }

    public async Task<IEnumerable<UserDatabase>> GetCardUsersAsync(Guid cardId)
    {
        string query = "select u.* from users u " +
                       "join card_users cu on u.id = cu.user_id " +
                       "where cu.card_id = $1";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId}
        };

        return await GetListAsync<UserDatabase>(query, parameters);
    }

    public async Task<bool> AddCardUserAsync(Guid cardId, Guid userId)
    {
        string query = "insert into card_users(card_id, user_id) values ($1, $2)";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId},
            new NpgsqlParameter {Value = userId},
        };

        return await ExecuteAsync(query, parameters);
    }

    // todo сделать транзакцией
    public async Task<bool> AddCardUsersAsync(Guid cardId, IEnumerable<Guid> userIds)
    {
        var result = true;

        foreach (var userId in userIds)
        {
            var res = await AddCardUserAsync(cardId, userId);

            if (res == false)
            {
                result = false;
            }
        }

        return result;
    }

    public async Task<bool> DeleteCardUserAsync(Guid cardId, Guid userId)
    {
        string query = "delete from card_users where card_id = $1 and user_id = $2";

        var parameters = new[]
        {
            new NpgsqlParameter {Value = cardId},
            new NpgsqlParameter {Value = userId}
        };

        return await ExecuteAsync(query, parameters);
    }

    public Task<bool> DeleteCardUserAsync(int id)
    {
        return DeleteAsync("card_users", "id", id);
    }
}