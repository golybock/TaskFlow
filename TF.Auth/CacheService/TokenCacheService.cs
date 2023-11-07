using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using TF.Auth.Models.Tokens;

namespace TF.Auth.CacheService;

public class TokenCacheService : ITokenCacheService
{
    private readonly IDistributedCache _cache;

    private string Key(string username, string refreshToken) => $"{username}:{refreshToken}";

    public TokenCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<ITokenPair?> GetTokensAsync(string username, string refreshToken)
    {
        var key = Key(username, refreshToken);

        var tokens = await _cache.GetAsync(key);

        if (tokens == null)
            return null;

        MemoryStream stream = new MemoryStream(tokens);

        return await JsonSerializer.DeserializeAsync<TokenPair>(stream);
    }

    public async Task<ITokenPair?> GetTokensAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task SetTokensAsync(string username, ITokenPair tokenPair, TimeSpan refreshTokenLifeTime)
    {
        await SetTokensAsync(username, tokenPair, refreshTokenLifeTime.Ticks);
    }

    public async Task SetTokensAsync(string username, ITokenPair tokenPair, long refreshTokenLifeTimeTicks)
    {
        var tokenLifeTime = DateTime.UtcNow.AddTicks(refreshTokenLifeTimeTicks);

        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTimeOffset(tokenLifeTime)
        };

        var key = Key(username, tokenPair.RefreshToken);

        var value = JsonSerializer.Serialize(tokenPair);

        await _cache.SetStringAsync(key, value, options);
    }

    public async Task DeleteTokensAsync(string username, string refreshToken)
    {
        var key = Key(username, refreshToken);

        await _cache.RemoveAsync(key);
    }

    public async Task DeleteTokensAsync(string username)
    {
        throw new NotImplementedException();
    }
}