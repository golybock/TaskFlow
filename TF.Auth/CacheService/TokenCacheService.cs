using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using TF.Auth.Tokens;

namespace TF.Auth.CacheService;

public class TokenCacheService : ITokenCacheService
{
    private readonly IDistributedCache _cache;

    private string Key(IUserModel user, string refreshToken) => $"{user.Username}:{refreshToken}";

    public TokenCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<ITokensPair?> GetTokens(IUserModel user, string refreshToken)
    {
        var key = Key(user, refreshToken);

        var tokens = await _cache.GetAsync(key);

        if (tokens == null)
            return null;

        MemoryStream stream = new MemoryStream(tokens);

        return await JsonSerializer.DeserializeAsync<TokensPair>(stream);
    }

    public async Task SetTokens(IUserModel user, ITokensPair tokensPair, TimeSpan refreshTokenLifeTime)
    {
        await SetTokens(user, tokensPair, refreshTokenLifeTime.Ticks);
    }

    public async Task SetTokens(IUserModel user, ITokensPair tokensPair, long refreshTokenLifeTime)
    {
        var tokenLifeTime = DateTime.UtcNow.AddTicks(refreshTokenLifeTime);

        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTimeOffset(tokenLifeTime)
        };

        var key = Key(user, tokensPair.RefreshToken);

        var value = JsonSerializer.Serialize(tokensPair);

        await _cache.SetStringAsync(key, value, options);
    }

    public async Task DeleteTokens(IUserModel user, string refreshToken)
    {
        var key = Key(user, refreshToken);

        await _cache.RemoveAsync(key);
    }
}