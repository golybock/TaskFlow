using Microsoft.AspNetCore.Mvc;
using TF.Auth.Controller;
using TF.BlankModels.Models.User;
using TF.Services.Services.Users;
using TF.ViewModels.Models.User;

namespace TF.API.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
// todo refactor
public class UserController : ControllerBase<UserView>
{
    private UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult?> GetUserAsync(Guid? id, String? usernameOrEmail)
    {
        UserView? userView = null;

        if (id != null)
        {
            userView =  await _userService.GetUserAsync(id.Value);
        }

        if (usernameOrEmail != null)
        {
            userView =  await _userService.GetUserAsync(usernameOrEmail);
        }

        IActionResult res = userView == null ? BadRequest() : Ok(userView);

        return res;
    }

    [HttpPost("[action]")]
    public Task<IActionResult> CreateUserAsync(UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    [HttpPut("[action]")]
    public Task<IActionResult> UpdateUserAsync(Guid id, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    [HttpPut("[action]")]
    public Task<IActionResult> UpdateUserAsync(String usernameOrEmail, UserBlank userBlank)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        var res = await _userService.DeleteUserAsync(id);

        return res ? Ok() : BadRequest();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteUserAsync(String username)
    {
        var res = await _userService.DeleteUserAsync(username);

        return res ? Ok() : BadRequest();
    }
}