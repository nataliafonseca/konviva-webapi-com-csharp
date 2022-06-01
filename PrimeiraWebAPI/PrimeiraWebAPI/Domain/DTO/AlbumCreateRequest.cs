using System.ComponentModel.DataAnnotations;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class AlbumCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O artista é obrigatório!")]
        public string Artista { get; set; }

        [Required]
        public int? AnoLancamento { get; set; }
        // int? e Required
        // Quando utilizamos int, sem ?, é passado o valor padrão 0,
        // assim, a API não tem como saber se o valor recebido foi passado
        // na requisição ou o valor padrão, por isso, utilizamos int?
        // para que não seja passado um valor padrão!
    }
}
