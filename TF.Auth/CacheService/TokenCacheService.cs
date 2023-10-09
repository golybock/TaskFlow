using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using TF.Auth.Tokens;

namespace TF.Auth.CacheService;

public class TokenCacheService : ITokenCacheService
{
    private readonly IDistributedCache _cache;

    private string Key(Guid userId, string refreshToken) => $"{userId}:{refreshToken}";

    #region parse key

        private Guid GetUserIdFromKey(string key)
    {
        var values = key.Split(':');

        return Guid.Parse(values[0]); 
    }
    
    private string GetRefreshTokenFromKey(string key)
    {
        var values = key.Split(':');

        return values[1];
    }
    

    #endregion

    public TokenCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<ITokensModel?> GetTokens(Guid userId, string refreshToken)
    {
        var key = Key(userId, refreshToken);
        
        var tokens = await _cache.GetStringAsync(key);

        if (tokens == null)
            return null;

        return JsonSerializer.Deserialize<TokensModelModel>(tokens);
    }

    public async Task SetTokens(Guid userId, ITokensModel tokensModel, TimeSpan refreshTokenLifeTime)
    {
        var tokenLifeTime = DateTime.UtcNow.AddDays(refreshTokenLifeTime.TotalDays);
        
        // tokens pair can be deleted when refresh token expired
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTimeOffset(tokenLifeTime)
        };

        var key = Key(userId, tokensModel.RefreshToken);

        var value = JsonSerializer.Serialize(tokensModel);

        await _cache.SetStringAsync(key, value, options);
    }

    public async Task SetTokens(Guid userId, ITokensModel tokensModel, int refreshTokenLifeTimeInDays)
    {
        var tokenLifeTime = DateTime.UtcNow.AddDays(refreshTokenLifeTimeInDays);
        
        // tokens pair can be deleted when refresh token expired
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = new DateTimeOffset(tokenLifeTime)
        };

        var key = Key(userId, tokensModel.RefreshToken);

        var value = JsonSerializer.Serialize(tokensModel);

        await _cache.SetStringAsync(key, value, options);
    }

    public async Task DeleteTokens(Guid userId, string refreshToken)
    {
        var key = Key(userId, refreshToken);

        await _cache.RemoveAsync(key);
    }
}