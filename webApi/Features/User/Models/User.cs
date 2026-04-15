using System.ComponentModel.DataAnnotations;
using CompanyEntity = webApi.Features.Company.Models.Company;

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

        /*CHAVE ESTRANGEIRA, REFERENCIANDO A UMA EMPRESA CADASTRADA
        RELACIONAMENTO (1:1)
        */
        [Required]
        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;
    }
}
