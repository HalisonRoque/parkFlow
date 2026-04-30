using webApi.Features.Ticket.Dtos;
using webApi.Features.Ticket.Repository;
using TicketEntity = webApi.Features.Ticket.Models.Ticket;

namespace webApi.Features.Ticket.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRespository;

        public TicketService(ITicketRepository ticket)
        {
            _ticketRespository = ticket;
        }

        public async Task<List<ResponseTicketDto>> GetAllTicketAsync()
        {
            var tickets = await _ticketRespository.GetAllTicketAsync();

            return tickets
                .Select(t => new ResponseTicketDto
                {
                    Id = t.Id,
                    EntryTime = t.EntryTime,
                    ExitTime = t.EntryTime,
                    TotalPrice = t.TotalPrice,
                    VehicleId = t.VehicleId,
                    ParkingSpotId = t.ParkingSpotId,
                })
                .ToList();
        }

        public async Task<ResponseTicketDto> GetTicketByIdAsync(int id)
        {
            var ticket = await _ticketRespository.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                throw new Exception("Ticket não encontrado");
            }

            return new ResponseTicketDto
            {
                Id = ticket.Id,
                EntryTime = ticket.EntryTime,
                ExitTime = ticket.EntryTime,
                TotalPrice = ticket.TotalPrice,
                VehicleId = ticket.VehicleId,
                ParkingSpotId = ticket.ParkingSpotId,
            };
        }

        public async Task<ResponseTicketDto> CreateTicketAsync(CreateTicketDto ticket)
        {
            var newTicket = new TicketEntity
            {
                EntryTime = ticket.EntryTime,
                VehicleId = ticket.VehicleId,
                ParkingSpotId = ticket.ParkingSpotId,
            };

            var createTicket = await _ticketRespository.CreateTicketAsync(newTicket);

            return new ResponseTicketDto
            {
                Id = createTicket.Id,
                EntryTime = createTicket.EntryTime,
                ExitTime = createTicket.ExitTime,
                TotalPrice = createTicket.TotalPrice,
                VehicleId = createTicket.VehicleId,
                ParkingSpotId = createTicket.ParkingSpotId,
            };
        }

        public async Task<ResponseTicketDto> UpdateTicketAsync(int id, UpdateTicketDto ticketDto)
        {
            var findTicket = await _ticketRespository.GetTicketByIdAsync(id);

            if (findTicket == null)
            {
                throw new Exception("Ticket não encontrado");
            }

            findTicket.EntryTime = ticketDto.EntryTime;
            findTicket.ExitTime = ticketDto.ExitTime;
            findTicket.TotalPrice = ticketDto.TotalPrice;

            await _ticketRespository.UpdateTicketAsync(findTicket);

            return new ResponseTicketDto
            {
                Id = findTicket.Id,
                EntryTime = findTicket.EntryTime,
                ExitTime = findTicket.ExitTime,
                TotalPrice = findTicket.TotalPrice,
                VehicleId = findTicket.VehicleId,
                ParkingSpotId = findTicket.ParkingSpotId,
            };
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _ticketRespository.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                throw new Exception("Ticket não encontrado");
            }

            await _ticketRespository.DeleteTicketAsync(ticket);
        }
    }
}
