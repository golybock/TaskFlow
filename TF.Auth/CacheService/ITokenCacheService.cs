using TF.Auth.Models.Tokens;

namespace TF.Auth.CacheService;

public interface ITokenCacheService
{
    public Task<ITokenPair?> GetTokensAsync(string username, string refreshToken);

    public Task<ITokenPair?> GetTokensAsync(string username);

    public Task SetTokensAsync(string username, ITokenPair tokenPair, TimeSpan refreshTokenLifeTime);

    public Task SetTokensAsync(string username, ITokenPair tokenPair, long refreshTokenLifeTimeTicks);

    public Task DeleteTokensAsync(string username, string refreshToken);

    public Task DeleteTokensAsync(string username);
}