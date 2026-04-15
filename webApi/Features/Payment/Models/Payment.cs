using System.ComponentModel.DataAnnotations;
using CompanyEntity = webApi.Features.Company.Models.Company;
using TicketEntity = webApi.Features.Ticket.Models.Ticket;

namespace webApi.Features.Payment.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string Method { get; set; } = string.Empty;

        [Required]
        public int TicketId { get; set; }
        public TicketEntity Ticket { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;
    }
}
