using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF.Services.Services;

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

        [HttpPost]
        public async Task<IActionResult> SignIn(string login, string password)
        {
            return await _authService.SignIn(login, password);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp()
        {
            return await _authService.SignUp();
        }

        [HttpPost]
        public new async Task<IActionResult> SignOut()
        {
            return await _authService.SignOut();
        }
    }
}
