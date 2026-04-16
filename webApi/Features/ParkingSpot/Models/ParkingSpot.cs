using System.ComponentModel.DataAnnotations;

namespace webApi.Features.ParkingSpot.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public bool IsOccupied { get; set; }
    }
}
