using Microsoft.EntityFrameworkCore;
using webApi.Data;
using UserEntity = webApi.Features.User.Models.User;

namespace webApi.Features.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> GetAllUserAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<UserEntity?> GetUserByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserEntity?> GetUserByNameAsync(string name)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<UserEntity> CreateUserAsync(UserEntity user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntity> UpdateUserAsync(UserEntity user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(UserEntity user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
