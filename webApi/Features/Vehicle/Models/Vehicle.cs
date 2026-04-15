using System.ComponentModel.DataAnnotations;
using CompanyEntity = webApi.Features.Company.Models.Company;

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
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;
    }
}
