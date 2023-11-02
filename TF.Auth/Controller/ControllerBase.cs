using System.Security.Claims;
using System.Text.Json;
using TF.Auth.AuthManager;

namespace TF.Auth.Controller;

// T - UserType
public class ControllerBase<T> : Microsoft.AspNetCore.Mvc.ControllerBase
{
    // private IAuthManager _authManager;

    // public ControllerBase(IAuthManager authManager)
    // {
    //     _authManager = authManager;
    // }

    // username
    public new T? User
    {
        get
        {
            // не может быть null
            var json = base.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Authentication)!.ValueType;

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}