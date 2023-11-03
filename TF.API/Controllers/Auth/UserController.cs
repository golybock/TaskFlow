using Microsoft.AspNetCore.Mvc;
using TF.Auth.Controller;
using TF.BlankModels.Models.User;
using TF.Services.Services.Users;
using TF.ViewModels.Models.User;

namespace TF.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase<UserView>
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult?> GetUserAsync(Guid? id, String? usernameOrEmail)
    {
        if (id != null)
        {
            return await _userService.GetUserAsync(id.Value);
        }

        if (usernameOrEmail != null)
        {
            return await _userService.GetUserAsync(usernameOrEmail);
        }

        return BadRequest("Invalid request data, please set id or username or email");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUserAsync(UserBlank userBlank)
    {
        return await _userService.CreateUserAsync(userBlank);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUserAsync(Guid? id, String? usernameOrEmail, UserBlank userBlank)
    {
        if (id != null)
        {
            return await _userService.UpdateUserAsync(id.Value, userBlank);
        }

        if (usernameOrEmail != null)
        {
            return await _userService.UpdateUserAsync(usernameOrEmail, userBlank);
        }

        return BadRequest("Invalid request data, please set id or username or email");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUserPasswordAsync(Guid? id, String? usernameOrEmail, UserBlank userBlank)
    {
        if (id != null)
        {
            return await _userService.UpdateUserPasswordAsync(id.Value, userBlank);
        }

        if (usernameOrEmail != null)
        {
            return await _userService.UpdateUserPasswordAsync(usernameOrEmail, userBlank);
        }

        return BadRequest("Invalid request data, please set id or username or email");
    }


    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        return await _userService.DeleteUserAsync(id);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteUserAsync(String username)
    {
        return await _userService.DeleteUserAsync(username);
    }
}