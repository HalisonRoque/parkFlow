using System.ComponentModel.DataAnnotations;
using ParkingSpotEntity = webApi.Features.ParkingSpot.Models.ParkingSpot;
using VehicleEntity = webApi.Features.Vehicle.Models.Vehicle;

namespace webApi.Features.Ticket.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public DateTime EntryTime { get; set; }

        public DateTime? ExitTime { get; set; }

        public decimal? TotalPrice { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public VehicleEntity Vehicle { get; set; } = null!;

        [Required]
        public int ParkingSpotId { get; set; }
        public ParkingSpotEntity ParkingSpot { get; set; } = null!;
    }
}
