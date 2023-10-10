using Microsoft.AspNetCore.Mvc;

namespace TF.Services.Services;

public interface IAuthService
{
    public Task<IActionResult> SignIn(string login, string password);

    public Task<IActionResult> SignUp();

    public Task<IActionResult> SignOut();
}