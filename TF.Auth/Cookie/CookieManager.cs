using Microsoft.AspNetCore.Http;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public class CookieManager : CookieManagerBase, ICookieManager
{
     private CookieOptions DefaultOptions(DateTime expires) =>
        new (){Expires = expires, Secure = true, SameSite = SameSiteMode.None};

    private CookieOptions DefaultOptions() =>
        new (){Secure = true, SameSite = SameSiteMode.None};

    public ITokensPair? GetTokens(HttpContext context)
    {
        string? token = GetRequestCookie(context, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(context, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new Tokens.TokensPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public ITokensPair? GetTokens(HttpRequest request)
    {
        string? token = GetRequestCookie(request, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(request, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new Tokens.TokensPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public void SetTokens(HttpContext context, ITokensPair tokensPair, long refreshTokenLifeTime)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddTicks(refreshTokenLifeTime);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(context, CookieTypes.Token, tokensPair.Token, options);
        AppendResponseCookie(context, CookieTypes.RefreshToken, tokensPair.RefreshToken, options);
    }

    public void SetTokens(HttpResponse response, ITokensPair tokensPairDomain, long refreshTokenLifeTime)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddTicks(refreshTokenLifeTime);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(response, CookieTypes.Token, tokensPairDomain.Token, options);
        AppendResponseCookie(response, CookieTypes.RefreshToken, tokensPairDomain.RefreshToken, options);
    }

    public void DeleteTokens(HttpContext context)
    {
        var options = DefaultOptions();

        DeleteCookie(context, CookieTypes.Token, options);
        DeleteCookie(context, CookieTypes.RefreshToken, options);
    }

    public void DeleteTokens(HttpResponse response)
    {
        var options = DefaultOptions();

        DeleteCookie(response, CookieTypes.Token, options);
        DeleteCookie(response, CookieTypes.RefreshToken, options);
    }
}