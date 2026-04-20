using Microsoft.AspNetCore.Mvc;
using webApi.Features.User.Dtos;
using webApi.Features.User.Services;

namespace webApi.Features.User.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto body)
        {
            var user = await _userService.CreateUserAsync(body);
            return Ok(user);
        }
    }
}
