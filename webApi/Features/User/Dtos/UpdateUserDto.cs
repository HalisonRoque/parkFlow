using System.ComponentModel.DataAnnotations;

namespace webApi.Features.User.Dtos
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(80, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "A idade deve estar entre 1 e 120 anos.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string? Password { get; set; } = string.Empty;
    }
}
