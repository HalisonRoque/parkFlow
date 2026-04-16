using System.ComponentModel.DataAnnotations;
using ClientEntity = webApi.Features.Client.Models.Client;

namespace webApi.Features.Vehicle.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Plate { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; } = null!;
    }
}
