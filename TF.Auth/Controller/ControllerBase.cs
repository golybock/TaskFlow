using System.Security.Claims;
using System.Text.Json;
using TF.Auth.AuthManager;

namespace TF.Auth.Controller;

// T - UserType
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
    // private IAuthManager _authManager;

    // public ControllerBase(IAuthManager authManager)
    // {
    //     _authManager = authManager;
    // }

    // username
    protected new string User =>  base.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;

    protected Guid UserId =>
        Guid.Parse(base.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Authentication)!.Value);
}