using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraWebAPI.Domain.Entity
{
    [Table("Albuns")]
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Artista { get; set; }

        [Required]
        public int AnoLancamento { get; set; }
    }
}