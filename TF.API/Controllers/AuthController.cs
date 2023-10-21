using Microsoft.AspNetCore.Mvc;
using TF.BlankModels.Models.User;
using TF.Services.Services.Auth;

namespace TF.API.Controllers
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

        [HttpPost(nameof(SignIn))]
        public async Task<IActionResult> SignIn(string login, string password)
        {
            return await _authService.SignIn(login, password, HttpContext);
        }

        [HttpPost(nameof(SignUp))]
        public async Task<IActionResult> SignUp(UserBlank userBlank)
        {
            return await _authService.SignUp(userBlank, HttpContext);
        }

        [HttpPost(nameof(SignOut))]
        public new async Task<IActionResult> SignOut()
        {
            return await _authService.SignOut(HttpContext);
        }
    }
}
