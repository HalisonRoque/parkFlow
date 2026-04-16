using System.ComponentModel.DataAnnotations;
using UserEntity = webApi.Features.User.Models.User;

namespace webApi.Features.Client.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
