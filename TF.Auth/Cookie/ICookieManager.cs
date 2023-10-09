using Microsoft.AspNetCore.Http;
using TF.Auth.Tokens;

namespace TF.Auth.Cookie;

public interface ICookieManager
{
    public ITokensModel? GetTokens(HttpContext context);

    public ITokensModel? GetTokens(HttpRequest request);

    public void SetTokens(HttpContext context, ITokensModel tokensModel, int refreshTokenLifeTime);

    public void SetTokens(HttpResponse response, ITokensModel tokensModel, int refreshTokenLifeTime);

    public void DeleteTokens(HttpContext context);

    public void DeleteTokens(HttpResponse response);
}