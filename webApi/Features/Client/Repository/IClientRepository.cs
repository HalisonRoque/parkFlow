using ClientEntity = webApi.Features.Client.Models.Client;

namespace webApi.Features.Client.Repository
{
    public interface IClientRepository
    {
        Task<List<ClientEntity>> GetAllClientAsync();
        Task<ClientEntity> GetClientByIdAsync(int id);

        Task<ClientEntity> GetClientByNameAsync(string name);

        Task<ClientEntity> CreateClientAsync(ClientEntity client);

        Task<ClientEntity> UpdateClientAsync(ClientEntity client);

        Task DeleteClientAsync(int id);
    }
}
