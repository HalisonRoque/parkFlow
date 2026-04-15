using System.ComponentModel.DataAnnotations;
using CompanyEntity = webApi.Features.Company.Models.Company;

namespace webApi.Features.ParkingSpot.Models
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public bool IsOccupied { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;
    }
}
