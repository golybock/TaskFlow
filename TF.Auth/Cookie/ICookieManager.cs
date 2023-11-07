using Microsoft.AspNetCore.Http;
using TF.Auth.Models.Tokens;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public interface ICookieManager
{
    public ITokenPair? GetTokens(HttpContext context);

    public ITokenPair? GetTokens(HttpRequest request);

    public void SetTokens(HttpContext context, ITokenPair tokenPair, long refreshTokenLifeTime);

    public void SetTokens(HttpResponse response, ITokenPair tokenPair, long refreshTokenLifeTime);

    public void DeleteTokens(HttpContext context);

    public void DeleteTokens(HttpResponse response);
}