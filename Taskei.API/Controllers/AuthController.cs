using Microsoft.AspNetCore.Mvc;
using Taskei.API.DTOs;
using Taskei.API.Services;

namespace Taskei.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized("Invalid username or password.");

            return Ok(new { Token = token });
        }
    }
}