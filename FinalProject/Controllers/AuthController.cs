using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.DTOs;
using System.Threading.Tasks;

namespace FinalProject.Front.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var token = await authService.AuthenticateUser(loginDTO);

            if (token != null)
            {
                return Ok(new { token });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
    }
}
