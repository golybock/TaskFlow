using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TF.Auth.CacheService;
using TF.Auth.Tokens;

namespace TF.Auth.AuthManager;

public interface IAuthManager
{
    public Cookie.ICookieManager CookieManager { get; protected set; }
    
    public ITokenManager TokenManager { get; protected set; }
    
    public ITokenCacheService TokenCacheService { get; protected set; }

    public Task SignInAsync(HttpContext context, IUserModel user);
    
    public Task SignInAsync(HttpResponse response, IUserModel user);

    public Task SignInAsync(HttpResponse response, ClaimsPrincipal principal);
    
    public Task SignInAsync(HttpContext context, ClaimsPrincipal principal);
    
    public Task RefreshTokensAsync(HttpResponse response, ITokensPair tokens);

    public Task SignOutAsync(HttpContext context);

    public Task SignOutAsync(HttpResponse response);
}