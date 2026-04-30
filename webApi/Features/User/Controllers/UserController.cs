using Microsoft.AspNetCore.Mvc;
using webApi.Features.User.Dtos;
using webApi.Features.User.Services;

namespace webApi.Features.User.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
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

        [HttpGet("/findById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var users = await _userService.GetUserByIdAsync(id);
            return Ok(users);
        }

        [HttpGet("/findByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var users = await _userService.GetUserByNameAsync(name);
            return Ok(users);
        }

        [HttpGet("/findByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var users = await _userService.GetUserByEmailAsync(email);
            return Ok(users);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto user)
        {
            await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
