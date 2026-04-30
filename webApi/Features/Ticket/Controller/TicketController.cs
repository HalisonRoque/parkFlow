using Microsoft.AspNetCore.Mvc;
using webApi.Features.Ticket.Dtos;
using webApi.Features.Ticket.Services;

namespace webApi.Features.Ticket.Controller
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTicket()
        {
            var ticket = await _ticketService.GetAllTicketAsync();
            return Ok(ticket);
        }

        [HttpGet("ticket/{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return Ok(ticket);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDto body)
        {
            var ticket = await _ticketService.CreateTicketAsync(body);
            return Ok(ticket);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] UpdateTicketDto body)
        {
            await _ticketService.UpdateTicketAsync(id, body);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
