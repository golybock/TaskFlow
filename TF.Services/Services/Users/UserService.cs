using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;
using TF.DatabaseModels.Models.User;
using TF.DomainModels.Models.User;
using TF.Repositories.Repositories.Users;
using TF.Tools.Crypto;
using TF.Tools.Enums;
using TF.ViewModels.Models.User;

namespace TF.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IActionResult> GetUserAsync(Guid id)
    {
        var user = await GetUserView(id);

        if (user == null)
            return new NotFoundResult();

        return new OkObjectResult(user);
    }

    public async Task<IActionResult> GetUserAsync(string usernameOrEmail)
    {
        var user = await GetUserView(usernameOrEmail);

        if (user == null)
            return new NotFoundResult();

        return new OkObjectResult(user);
    }

    public async Task<IActionResult> CreateUserAsync(UserBlank userBlank)
    {
        var res = await CreateUserDatabaseAsync(userBlank);

        return res ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UpdateUserPasswordAsync(Guid id, UserBlank userBlank)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return new NotFoundResult();

        var hashedPassword = await Crypto.HashSha512Async(userBlank.Password!);

        user.Password = hashedPassword;

        var res = await _userRepository.UpdateUserAsync(id, user);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка обновления данных");
    }

    public async Task<IActionResult> UpdateUserPasswordAsync(string usernameOrEmail, UserBlank userBlank)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return new NotFoundResult();

        var hashedPassword = await Crypto.HashSha512Async(userBlank.Password!);

        user.Password = hashedPassword;

        var res = await _userRepository.UpdateUserAsync(usernameOrEmail, user);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка обновления данных");
    }

    public async Task<IActionResult> UpdateUserAsync(Guid id, UserBlank userBlank)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return new NotFoundResult();

        var letters = GetUserLetters(userBlank.FullName);

        user.FullName = userBlank.FullName;
        user.Letters = letters;
        user.Email = userBlank.Email;
        user.RoleId = userBlank.Role;
        user.ImageUrl = userBlank.ImageUrl;

        var res = await _userRepository.UpdateUserAsync(id, user);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка обновления данных");
    }

    public async Task<IActionResult> UpdateUserAsync(string usernameOrEmail, UserBlank userBlank)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return new NotFoundResult();

        var letters = GetUserLetters(userBlank.FullName);

        user.FullName = userBlank.FullName;
        user.Letters = letters;
        user.Email = userBlank.Email;
        user.RoleId = userBlank.Role;
        user.ImageUrl = userBlank.ImageUrl;

        var res = await _userRepository.UpdateUserAsync(usernameOrEmail, user);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка обновления данных");
    }

    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        var res = await _userRepository.DeleteUserAsync(id);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка удаления");
    }

    public async Task<IActionResult> DeleteUserAsync(string username)
    {
        var res = await _userRepository.DeleteUserAsync(username);

        return res ? new OkResult() : new BadRequestObjectResult("Ошибка удаления");
    }

    private string GetUserLetters(string value)
    {
        return $"{value.ElementAt(0)}{value.ElementAt(1)}";
    }

    private async Task<Boolean> CreateUserDatabaseAsync(UserBlank userBlank)
    {
        var hashedPassword = await Crypto.HashSha512Async(userBlank.Password!);

        var letters = GetUserLetters(userBlank.FullName);

        var userDatabase = new UserDatabase(
            Guid.NewGuid(),
            userBlank.FullName,
            userBlank.UserName,
            userBlank.Email,
            hashedPassword,
            letters,
            userBlank.ImageUrl,
            userBlank.Role,
            false
        );

        return await _userRepository.CreateUserAsync(userDatabase);
    }

    private async Task<UserView?> GetUserView(Guid id)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return null;

        var userView = new UserView(new UserDomain(user));

        return userView;
    }

    private async Task<UserView?> GetUserView(string usernameOrEmail)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return null;

        var userView = new UserView(new UserDomain(user));

        return userView;
    }
}