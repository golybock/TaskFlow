using TF.Auth.Tokens;

namespace TF.Auth.CacheService;

public interface ITokenCacheService
{
    public Task<ITokensPair?> GetTokens(IUserModel user, string refreshToken);

    public Task SetTokens(IUserModel user, ITokensPair tokensPair, TimeSpan refreshTokenLifeTime);

    public Task SetTokens(IUserModel user, ITokensPair tokensPair, long refreshTokenLifeTime);

    public Task DeleteTokens(IUserModel user, string refreshToken);
}