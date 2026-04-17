using Microsoft.EntityFrameworkCore;
using webApi.Data;
using TicketEntity = webApi.Features.Ticket.Models.Ticket;

namespace webApi.Features.Ticket.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TicketEntity>> GetAllTicketAsync()
        {
            return await _context.Ticket.ToListAsync();
        }

        public async Task<TicketEntity?> GetTicketByIdAsync(int id)
        {
            return await _context.Ticket.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TicketEntity> CreateTicketAsync(TicketEntity ticket)
        {
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<TicketEntity> UpdateTicketAsync(TicketEntity ticket)
        {
            _context.Ticket.Update(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task DeleteTicketAsync(TicketEntity ticket)
        {
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
