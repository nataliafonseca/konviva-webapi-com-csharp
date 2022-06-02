using System.ComponentModel.DataAnnotations;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class AvaliacaoCreateRequest
    {
        [Required]
        public int IdAlbum { get; set; }
        [Required]
        public int Nota { get; set; }
        public string Comentario { get; set; }
    }
}
