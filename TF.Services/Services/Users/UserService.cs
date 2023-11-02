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
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
            return null;

        return new UserView(new UserDomain(user));
    }

    public async Task<IActionResult> GetUserAsync(string usernameOrEmail)
    {
        var user = await _userRepository.GetUserAsync(usernameOrEmail);

        if (user == null)
            return null;

        return new UserView(new UserDomain(user));
    }

    // todo refactor
    // todo validate
    public async Task<IActionResult> CreateUserAsync(UserBlank userBlank)
    {
        return (await CreateUserDatabaseAsync(userBlank)) != null;
    }

    public async Task<IActionResult> UpdateUserAsync(Guid id, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateUserAsync(string usernameOrEmail, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }

    public async Task<IActionResult> DeleteUserAsync(string username)
    {
        return await _userRepository.DeleteUserAsync(username);
    }

    private Task<byte[]> HashAsync(string value)
    {
        return Crypto.HashSha512Async(value);
    }


    private string GetUserLetters(string value)
    {
        return $"{value.ElementAt(0)}{value.ElementAt(1)}";
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
}