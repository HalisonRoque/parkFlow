using webApi.Features.Ticket.Dtos;

namespace webApi.Features.Ticket.Services
{
    public interface ITicketService
    {
        Task<List<ResponseTicketDto>> GetAllTicketAsync();

        Task<ResponseTicketDto> GetTicketByIdAsync(int id);

        Task<ResponseTicketDto> CreateTicketAsync(CreateTicketDto ticket);

        Task<ResponseTicketDto> UpdateTicketAsync(int id, UpdateTicketDto ticketDto);

        Task DeleteTicketAsync(int id);
    }
}
