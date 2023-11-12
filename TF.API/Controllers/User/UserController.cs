using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;
using TF.Services.Services.Users;
using ControllerBase = TF.Auth.Controller.ControllerBase;

namespace TF.API.Controllers.User;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
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

    [HttpGet("[action]")]
    public async Task<IActionResult?> GetProfileAsync()
    {
        return await _userService.GetUserAsync(User);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUserAsync(UserBlank userBlank)
    {
        return await _userService.CreateUserAsync(userBlank);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUserAsync(UserBlank userBlank)
    {
        return await _userService.UpdateUserAsync(User, userBlank);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdatePasswordAsync(UserBlank userBlank)
    {
        return await _userService.UpdateUserPasswordAsync(User, userBlank);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        return await _userService.DeleteUserAsync(id);
    }
}