using System.ComponentModel.DataAnnotations;

namespace ApiAdocao.Domain.DTO
{
    public class AnimalCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required]
        public int? Idade { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Especie { get; set; }

        public DateTime? DataNascimento { get; set; }

        [Required]
        public int? NivelFofura { get; set; }

        [Required]
        public int? NivelCarinho { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
