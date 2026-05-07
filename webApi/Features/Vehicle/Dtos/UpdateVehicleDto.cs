using System.ComponentModel.DataAnnotations;

namespace webApi.Features.Vehicle.Dtos
{
    public class UpdateVehicleDto
    {
        [Required(ErrorMessage = "A Placa é obrigatório.")]
        [MaxLength(20)]
        public string Plate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Modelo deve ser informado")]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;
    }
}
