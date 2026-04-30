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
                    Email = u.Email,
                    Age = u.Age,
                })
                .ToList();
        }

        public async Task<ResponseUserDto?> GetUserByIdAsync(int id)
        {
            var findUser = await _userRepository.GetUserByIdAsync(id);

            if (findUser == null)
            {
                throw new Exception("usuário não encontrado");
            }

            return new ResponseUserDto
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Email = findUser.Email,
                Age = findUser.Age,
            };
        }

        public async Task<ResponseUserDto?> GetUserByNameAsync(string name)
        {
            var findUser = await _userRepository.GetUserByNameAsync(name);

            if (findUser == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return new ResponseUserDto
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Email = findUser.Email,
                Age = findUser.Age,
            };
        }

        public async Task<ResponseUserDto?> GetUserByEmailAsync(string email)
        {
            var findUser = await _userRepository.GetUserByEmailAsync(email);

            if (findUser == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return new ResponseUserDto
            {
                Id = findUser.Id,
                Name = findUser.Name,
                Email = findUser.Email,
                Age = findUser.Age,
            };
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

        public async Task<ResponseUserDto> UpdateUserAsync(int id, UpdateUserDto user)
        {
            var updateUser = await _userRepository.GetUserByIdAsync(id);

            if (updateUser == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Age = user.Age;

            await _userRepository.UpdateUserAsync(updateUser);

            return new ResponseUserDto
            {
                Id = updateUser.Id,
                Name = updateUser.Name,
                Email = updateUser.Email,
                Age = updateUser.Age,
            };
        }

        public async Task DeleteUserAsync(int id)
        {
            var deleteUser = await _userRepository.GetUserByIdAsync(id);

            if (deleteUser == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            await _userRepository.DeleteUserAsync(deleteUser);
        }
    }
}
