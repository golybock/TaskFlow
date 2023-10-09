using TF.Auth.Tokens;

namespace TF.Auth.CacheService;

public interface ITokenCacheService
{
    public Task<ITokensModel?> GetTokens(Guid userId, string refreshToken);

    public Task SetTokens(Guid userId, ITokensModel tokensModel, TimeSpan refreshTokenLifeTime);

    public Task SetTokens(Guid userId, ITokensModel tokensModel, int refreshTokenLifeTime);

    public Task DeleteTokens(Guid userId, string refreshToken);
}