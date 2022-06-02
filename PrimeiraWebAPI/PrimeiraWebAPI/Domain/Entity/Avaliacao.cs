﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraWebAPI.Domain.Entity
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public int IdAvaliacao { get; set; }

        [Required]
        public int IdAlbum { get; set; }

        [Required]
        public int Nota { get; set; }

        [StringLength(255)]
        public string Comentario { get; set; }

        public virtual Album Album { get; set; }
    }
}
