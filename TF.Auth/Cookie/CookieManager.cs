using Microsoft.AspNetCore.Http;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public class CookieManager : CookieManagerBase, ICookieManager
{
     private CookieOptions DefaultOptions(DateTime expires) =>
        new (){Expires = expires, Secure = true, SameSite = SameSiteMode.None};

    private CookieOptions DefaultOptions() =>
        new (){Secure = true, SameSite = SameSiteMode.None};

    public ITokensModel? GetTokens(HttpContext context)
    {
        string? token = GetRequestCookie(context, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(context, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new Tokens.TokensModelModel()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public ITokensModel? GetTokens(HttpRequest request)
    {
        string? token = GetRequestCookie(request, CookieTypes.Token);

        string? refreshToken = GetRequestCookie(request, CookieTypes.RefreshToken);

        if (token == null || refreshToken == null)
            return null;

        var tokens = new Tokens.TokensModelModel()
        {
            Token = token,
            RefreshToken = refreshToken
        };

        return tokens;
    }

    public void SetTokens(HttpContext context, ITokensModel tokensModel, int refreshTokenLifeTime)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddDays(refreshTokenLifeTime);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(context, CookieTypes.Token, tokensModel.Token, options);
        AppendResponseCookie(context, CookieTypes.RefreshToken, tokensModel.RefreshToken, options);
    }

    public void SetTokens(HttpResponse response, ITokensModel tokensModelDomain, int refreshTokenLifeTime)
    {
        // validation lifetime from options
        var expires = DateTime.UtcNow.AddDays(refreshTokenLifeTime);

        // cookie expires and mode
        var options = DefaultOptions(expires);

        AppendResponseCookie(response, CookieTypes.Token, tokensModelDomain.Token, options);
        AppendResponseCookie(response, CookieTypes.RefreshToken, tokensModelDomain.RefreshToken, options);
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