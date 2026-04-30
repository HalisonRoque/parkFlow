using System.ComponentModel.DataAnnotations;

namespace webApi.Features.Ticket.Dtos
{
    public class UpdateTicketDto
    {
        [Required(ErrorMessage = "A data de entrada é obrigatória")]
        public DateTime EntryTime { get; set; }

        [Required(ErrorMessage = "A data de saída é obrigatória")]
        public DateTime ExitTime { get; set; }

        [Required(ErrorMessage = "O preço total é obrigatório")]
        public decimal TotalPrice { get; set; }
    }
}
