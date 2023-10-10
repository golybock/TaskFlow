using Microsoft.AspNetCore.Http;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public interface ICookieManager
{
    public ITokensPair? GetTokens(HttpContext context);

    public ITokensPair? GetTokens(HttpRequest request);

    public void SetTokens(HttpContext context, ITokensPair tokensPair, long refreshTokenLifeTime);

    public void SetTokens(HttpResponse response, ITokensPair tokensPair, long refreshTokenLifeTime);

    public void DeleteTokens(HttpContext context);

    public void DeleteTokens(HttpResponse response);
}