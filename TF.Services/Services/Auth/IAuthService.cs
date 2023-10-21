using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;

namespace TF.Services.Services.Auth;

public interface IAuthService
{
    public Task<IActionResult> SignIn(string login, string password, HttpContext context);

    public Task<IActionResult> SignUp(UserBlank userBlank, HttpContext context);

    public Task<IActionResult> SignOut(HttpContext context);
}