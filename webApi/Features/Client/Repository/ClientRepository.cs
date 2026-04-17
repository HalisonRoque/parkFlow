using Microsoft.EntityFrameworkCore;
using webApi.Data;
using ClientEntity = webApi.Features.Client.Models.Client;

namespace webApi.Features.Client.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientEntity>> GetAllClientAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<ClientEntity?> GetClientByIdAsync(int id)
        {
            return await _context.Client.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ClientEntity?> GetClientByNameAsync(string name)
        {
            return await _context.Client.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<ClientEntity> CreateClientAsync(ClientEntity client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<ClientEntity> UpdateClientAsync(ClientEntity client)
        {
            _context.Client.Update(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(ClientEntity client)
        {
            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
