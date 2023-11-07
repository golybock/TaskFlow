using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TF.Auth.CacheService;
using TF.Auth.Cookie;
using TF.Auth.Models.Tokens;
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

    public async Task SignInAsync(HttpContext context, string user, string role)
    {
        var tokens = CreateTokens(user, role);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(context, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpResponse response, string user, string role)
    {
        var tokens = CreateTokens(user, role);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(response, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpResponse response, ClaimsPrincipal claims)
    {
        var user = TokenManager.GetUserFromClaims(claims);

        var tokens = CreateTokens(claims.Claims);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(response, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task SignInAsync(HttpContext context, ClaimsPrincipal claims)
    {
        var user = TokenManager.GetUserFromClaims(claims);

        var tokens = CreateTokens(claims.Claims);

        await SaveTokensAsync(tokens, user);

        CookieManager.SetTokens(context, tokens, Options.RefreshTokenLifeTimeTicks);
    }

    public async Task RefreshTokensAsync(HttpResponse response, ITokenPair token)
    {
        var user = TokenManager.GetUserFromToken(token.Token);

        var claims = TokenManager.GetPrincipalFromExpiredToken(token.Token);

        var cachedTokens = await TokenCacheService.GetTokensAsync(user, token.RefreshToken);

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

    private async Task SaveTokensAsync(ITokenPair token, string user)
    {
        await TokenCacheService.SetTokensAsync(user, token, Options.RefreshTokenLifeTime);
    }

    private ITokenPair CreateTokens(string user, string role)
    {
        var claims = TokenManager.CreateIdentityClaims(user, role);

        var token = TokenManager.GenerateToken(claims);
        var refreshToken = TokenManager.GenerateRefreshToken();

        var tokens = new TokenPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;

    }

    private ITokenPair CreateTokens(IEnumerable<Claim> claims)
    {
        var token = TokenManager.GenerateToken(claims);
        var refreshToken = TokenManager.GenerateRefreshToken();

        var tokens = new TokenPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    // delete pair with key 'username:refreshToken' from cache
    private Task DeleteTokensCache(ITokenPair token, string user) =>
        TokenCacheService.DeleteTokensAsync(user, token.RefreshToken);
}