using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.DTOs;
using Rescaptepet.Application.Interfaces.Public;

namespace Rescaptepet.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var user = await _authService.RegisterAsync(dto);
            if (user == null)
                return BadRequest("El correo ya esta registrado");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _authService.LoginAsync(dto);
            if (user == null)
                return BadRequest("Correo o contrasela incorrectos");
            return Ok(user);    
        }
    }
}
