using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF.Auth.AuthManager;
using TF.BlankModels.Models.User;
using TF.DatabaseModels.Models.User;
using TF.DomainModels.Models.User;
using TF.Repositories.Repositories.Users;
using TF.Tools.Crypto;
using TF.Tools.Enums;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Auth;

// todo refactor
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    private readonly IAuthManager _authManager;

    public AuthService(IUserRepository userRepository, IAuthManager authManager)
    {
        _userRepository = userRepository;
        _authManager = authManager;
    }

    public async Task<IActionResult> SignIn(string login, string password, HttpContext context)
    {
        var user = await _userRepository.GetUserAsync(login);

        if (user == null)
            return new UnauthorizedObjectResult("Incorrect login or password");

        var hashedPassword = await HashAsync(password);

        if (hashedPassword != user.Password)
            return new UnauthorizedObjectResult("Incorrect login or password");

        // todo refactor
        var userView = new UserView(new UserDomain(user));

        await _authManager.SignInAsync(context, userView);

        return new OkResult();
    }

    public async Task<IActionResult> SignUp(UserBlank userBlank, HttpContext context)
    {
        var userByUsername = await _userRepository.GetUserAsync(userBlank.UserName);

        var userByEmail = await _userRepository.GetUserAsync(userBlank.Email);

        if (userByUsername != null)
            return new BadRequestObjectResult("Username already in use");

        if (userByEmail != null)
            return new BadRequestObjectResult("Email already in use");

        if (userBlank.Password == null)
            return new BadRequestObjectResult("Password required");

        var user = await CreateUserDatabaseAsync(userBlank);

        var userView = new UserView(new UserDomain(user));

        await _authManager.SignInAsync(context, userView);

        return new OkResult();
    }

    private async Task<UserDatabase?> CreateUserDatabaseAsync(UserBlank userBlank)
    {
        var hashedPassword = await HashAsync(userBlank.Password!);

        var letters = GetUserLetters(userBlank.FullName);

        var userDB = new UserDatabase(
            Guid.NewGuid(),
            userBlank.FullName,
            userBlank.UserName,
            userBlank.Email,
            hashedPassword,
            letters,
            userBlank.ImageUrl,
            Role.Admin,
            false
        );

        var res = await _userRepository.CreateUserAsync(userDB);

        if (res)
        {
            return userDB;
        }

        return null;
    }

    private string GetUserLetters(string value)
    {
        return $"{value.ElementAt(0)}{value.ElementAt(1)}";
    }

    public async Task<IActionResult> SignOut(HttpContext context)
    {
        await _authManager.SignOutAsync(context);

        // todo add url to login page
        return new RedirectResult("");
    }

    public Task<byte[]> HashAsync(string value)
    {
        return Crypto.HashSha512Async(value);
    }
}