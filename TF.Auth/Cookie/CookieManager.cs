using Microsoft.AspNetCore.Http;
using TF.Auth.Models.Tokens;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public class CookieManager : CookieManagerBase, ICookieManager
{
     private CookieOptions DefaultOptions(DateTime expires) =>
        new (){Expires = expires, Secure = true, SameSite = SameSiteMode.None};

    private CookieOptions DefaultOptions() =>
        new (){Secure = true, SameSite = SameSiteMode.None};

    public ITokenPair? GetTokens(HttpContext context)
    {
        string? token = GetRequestCookie(context, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(context, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new TokenPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public ITokenPair? GetTokens(HttpRequest request)
    {
        string? token = GetRequestCookie(request, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(request, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new TokenPair()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public void SetTokens(HttpContext context, ITokenPair tokenPair, long validTicks)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddTicks(validTicks);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(context, CookieTypes.Token, tokenPair.Token, options);
        AppendResponseCookie(context, CookieTypes.RefreshToken, tokenPair.RefreshToken, options);
    }

    public void SetTokens(HttpResponse response, ITokenPair tokenPairDomain, long validTicks)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddTicks(validTicks);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(response, CookieTypes.Token, tokenPairDomain.Token, options);
        AppendResponseCookie(response, CookieTypes.RefreshToken, tokenPairDomain.RefreshToken, options);
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