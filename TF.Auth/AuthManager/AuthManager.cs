using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TF.Auth.CacheService;
using TF.Auth.Cookie;
using TF.Auth.Options;
using TF.Auth.Tokens;

namespace TF.Auth.AuthManager;

public class AuthManager : IAuthManager
{
    public ICookieManager CookieManager { get; set; }
    public ITokenManager TokenManager { get; set; }
    public ITokenCacheService TokenCacheService { get; set; }

    // auth scheme options
    private RefreshCookieOptions Options { get; set; }

    public AuthManager(RefreshCookieOptions options, ITokenCacheService tokenCacheService, ITokenManager tokenManager)
    {
        Options = options;
        TokenCacheService = tokenCacheService;
        TokenManager = tokenManager;
        CookieManager = new CookieManager();
    }

    // override IpAddress.Parse
    private string? GetIpAddress(string ip)
    {
        try
        {
            if (ip == "localhost")
                return "127.0.0.1";

            return ip;
        }
        catch (Exception e)
        {
            return null;
        }
    }

    // signIn
    public async Task SignInAsync(HttpContext context, IUserModel user)
    {
        var tokens = CreateTokens(user);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(context, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpResponse response, IUserModel user)
    {
        var tokens = CreateTokens(user);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(response, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpResponse response, ClaimsPrincipal claims)
    {
        var user = TokenManager.GetUserFromClaims(claims);

        var tokens = CreateTokens(user);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(response, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpContext context, ClaimsPrincipal claims)
    {
        var user = TokenManager.GetUserFromClaims(claims);

        var tokens = CreateTokens(user);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(context, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task RefreshTokensAsync(HttpResponse response, ITokensPair tokens)
    {
        var user = TokenManager.GetUserFromToken(tokens.Token);

        var claims = TokenManager.GetPrincipalFromExpiredToken(tokens.Token);

        var cachedTokens = await TokenCacheService.GetTokens(user, tokens.RefreshToken);

        if (cachedTokens == null)
            throw new Exception("Tokens in cache not found");

        await DeleteTokensCache(cachedTokens, user);

        await SignInAsync(response, claims);
    }

    public async Task SignOutAsync(HttpContext context)
    {
        var tokens = CookieManager.GetTokens(context);

        CookieManager.DeleteTokens(context);

        if (tokens == null)
            return;

        var user = TokenManager.GetUserFromToken(tokens.Token);

        await DeleteTokensCache(tokens, user);
    }

    public async Task SignOutAsync(HttpResponse response)
    {
        var tokens = CookieManager.GetTokens(response.HttpContext);

        CookieManager.DeleteTokens(response);

        if (tokens == null)
            return;

        var user = TokenManager.GetUserFromToken(tokens.Token);

        await DeleteTokensCache(tokens, user);
    }

    private async Task SaveTokensAsync(ITokensPair tokens, IUserModel user)
    {
        await TokenCacheService.SetTokens(user, tokens, Options.RefreshTokenLifeTime);
    }

    private ITokensPair CreateTokens(IUserModel user)
    {
        var claims = TokenManager.CreateIdentityClaims(user);

        var token = TokenManager.GenerateToken(claims);
        var refreshToken = TokenManager.GenerateRefreshToken();

        var tokens = new TokensPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    // delete pair with key 'username:refreshToken' from cache
    private Task DeleteTokensCache(ITokensPair tokens, IUserModel user) =>
        TokenCacheService.DeleteTokens(user, tokens.RefreshToken);
}