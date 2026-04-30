using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace webApi.Features.Ticket.Dtos
{
    public class CreateTicketDto
    {
        [Required(ErrorMessage = "A data de entrada é obrigatório")]
        public DateTime EntryTime { get; set; }

        [Required(ErrorMessage = "Id do veículo é obrigatório")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Id da vaga é obrigatório")]
        public int ParkingSpotId { get; set; }
    }
}
