using UserEntity = webApi.Features.User.Models.User;

namespace webApi.Features.User.Repository
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAllUserAsync();
        Task<UserEntity?> GetUserByIdAsync(int id);

        Task<UserEntity?> GetUserByNameAsync(string name);

        Task<UserEntity?> GetUserByEmailAsync(string email);

        Task<UserEntity> CreateUserAsync(UserEntity user);

        Task<UserEntity> UpdateUserAsync(UserEntity user);

        Task DeleteUserAsync(UserEntity user);
    }
}
