using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;

namespace TF.Services.Services.Users;

public interface IUserService
{
    // all users can get info about self and another users
    public Task<IActionResult> GetUserAsync(Guid id);

    public Task<IActionResult> GetUserAsync(String usernameOrEmail);
    // admin can create users
    public Task<IActionResult> CreateUserAsync(UserBlank userBlank);

    // only self
    public Task<IActionResult> UpdateUserPasswordAsync(Guid id, UserBlank userBlank);

    public Task<IActionResult> UpdateUserPasswordAsync(String usernameOrEmail, UserBlank userBlank);

    public Task<IActionResult> UpdateUserAsync(Guid id, UserBlank userBlank);

    public Task<IActionResult> UpdateUserAsync(String usernameOrEmail, UserBlank userBlank);
    // only admin (delete self and another users)
    public Task<IActionResult> DeleteUserAsync(Guid id);

    public Task<IActionResult> DeleteUserAsync(String username);
}