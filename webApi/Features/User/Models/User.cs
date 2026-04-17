using System.ComponentModel.DataAnnotations;

namespace webApi.Features.User.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(120)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(200)]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
