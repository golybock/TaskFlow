using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;

namespace TF.Services.Services.Users;

public interface IUserService
{
    public Task<IActionResult> GetUserAsync(Guid id);

    public Task<IActionResult> GetUserAsync(String usernameOrEmail);

    public Task<IActionResult> CreateUserAsync(UserBlank userBlank);

    public Task<IActionResult> UpdateUserAsync(Guid id, UserBlank userBlank);

    public Task<IActionResult> UpdateUserAsync(String usernameOrEmail, UserBlank userBlank);

    public Task<IActionResult> DeleteUserAsync(Guid id);

    public Task<IActionResult> DeleteUserAsync(String username);
}