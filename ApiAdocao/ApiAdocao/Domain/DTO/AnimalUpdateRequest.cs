using System.ComponentModel.DataAnnotations;

namespace ApiAdocao.Domain.DTO
{
    public class AnimalUpdateRequest
    {
        [Required]
        public int? NivelFofura { get; set; }

        [Required]
        public int? NivelCarinho { get; set; }
    }
}
