using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF.Auth.AuthManager;
using TF.BlankModels.Models.User;
using TF.DomainModels.Models.User;
using TF.Repositories.Repositories.Users;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Auth;

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

        // todo add claims
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

        var hashedPassword = await HashAsync(userBlank.Password);

        // todo refactor
        //
        // await _authManager.SignInAsync(context, userView);

        return new OkResult();
    }

    public async Task<IActionResult> SignOut(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public async Task<byte[]> HashAsync(string value)
    {
        using var sha512 = new SHA512Managed();

        var valueBytes = Encoding.UTF8.GetBytes(value);

        Stream valueStream = new MemoryStream(valueBytes);

        return await sha512.ComputeHashAsync(valueStream);
    }
}