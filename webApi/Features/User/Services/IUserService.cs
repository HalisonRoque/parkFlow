using webApi.Features.User.Dtos;

namespace webApi.Features.User.Services
{
    public interface IUserService
    {
        Task<List<ResponseUserDto>> GetAllUserAsync();

        Task<ResponseUserDto?> GetUserByIdAsync(int id);

        Task<ResponseUserDto?> GetUserByNameAsync(string name);

        Task<ResponseUserDto> CreateUserAsync(CreateUserDto user);

        Task<ResponseUserDto> UpdateUserAsync(UpdateUserDto user);

        Task DeleteUserAsync(ResponseUserDto user);
    }
}
