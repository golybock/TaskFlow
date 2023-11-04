using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TF.Auth.Controller;
using TF.BlankModels.Models.User;
using TF.Services.Services.Auth;
using TF.ViewModels.Models.User;
using ControllerBase = TF.Auth.Controller.ControllerBase;

namespace TF.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(string login, string password)
        {
            return await _authService.SignIn(login, password, HttpContext);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(UserBlank userBlank)
        {
            return await _authService.SignUp(userBlank, HttpContext);
        }

        [Authorize]
        [HttpPost("[action]")]
        public new async Task<IActionResult> SignOut()
        {
            return await _authService.SignOut(HttpContext);
        }
    }
}
