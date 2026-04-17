using BCrypt.Net;
using webApi.Features.User.Dtos;
using webApi.Features.User.Repository;
using UserEntity = webApi.Features.User.Models.User;

namespace webApi.Features.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ResponseUserDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllUserAsync();

            return users
                .Select(u => new ResponseUserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Name,
                    Age = u.Age,
                })
                .ToList();
        }

        public async Task<ResponseUserDto> CreateUserAsync(CreateUserDto dto)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new UserEntity
            {
                Name = dto.Name.Trim(),
                Email = dto.Email.Trim().ToLower(),
                Age = dto.Age,
                PasswordHash = passwordHash,
            };

            var createUser = await _userRepository.CreateUserAsync(user);

            return new ResponseUserDto
            {
                Id = createUser.Id,
                Name = createUser.Name,
                Email = createUser.Email,
                Age = createUser.Age,
            };
        }

        public Task<ResponseUserDto?> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUserDto?> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseUserDto> UpdateUserAsync(UpdateUserDto user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(ResponseUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
