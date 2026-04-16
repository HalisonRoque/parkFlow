using TicketEntity = webApi.Features.Ticket.Models.Ticket;

namespace webApi.Features.Ticket.Repository
{
    public interface ITicketRepository
    {
        Task<List<TicketEntity>> GetAllTicketAsync();
        Task<TicketEntity> GetTicketByIdAsync(int id);

        Task<TicketEntity> CreateTicketAsync(TicketEntity ticket);

        Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket);

        Task DeleteTicketAsync(int id);
    }
}
