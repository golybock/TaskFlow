﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TF.Auth.CacheService;
using ICookieManager = NotesApi.RefreshCookieAuthScheme.Cookie.ICookieManager;

namespace TF.Auth.AuthManager;

public interface IAuthManager
{
    public ICookieManager CookieManager { get; protected set; }
    
    public ITokenManager TokenManager { get; protected set; }
    
    public ITokenCacheService TokenCacheService { get; protected set; }

    public Task SignInAsync(HttpContext context, UserDomain user);
    
    public Task SignInAsync(HttpResponse response, UserDomain user);

    public Task SignInAsync(HttpResponse response, ClaimsPrincipal principal);
    
    public Task SignInAsync(HttpContext context, ClaimsPrincipal principal);
    
    public Task RefreshTokensAsync(HttpResponse response, Tokens tokens);

    public Task SignOutAsync(HttpContext context);

    public Task SignOutAsync(HttpResponse response);
}