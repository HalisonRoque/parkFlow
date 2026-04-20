using Microsoft.AspNetCore.Mvc;
using webApi.Features.Auth.Dtos;
using webApi.Features.Auth.Services;
using webApi.Features.User.Dtos;
using webApi.Features.User.Repository;

namespace webApi.Features.Auth.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthService _authService;

        public AuthController(IUserRepository repo, AuthService authService)
        {
            _userRepository = repo;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var token = await _authService.AuthenticateAsync(login);

            if (token == null)
                return Unauthorized(new { message = "E-mail ou senha inválidos" });

            return Ok(new { token });
        }
    }
}
