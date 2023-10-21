using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;
using TF.Repositories.Repositories.Users;

namespace TF.Services.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> SignIn(string login, string password, HttpContext context)
    {
        var user = await _userRepository.GetUserAsync(login);

        return new OkObjectResult(user);
    }

    public async Task<IActionResult> SignUp(UserBlank userBlank, HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> SignOut(HttpContext context)
    {
        throw new NotImplementedException();
    }
}