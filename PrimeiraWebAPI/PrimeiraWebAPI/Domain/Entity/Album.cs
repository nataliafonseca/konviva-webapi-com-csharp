﻿namespace PrimeiraWebAPI.Domain.Entity
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public int AnoLancamento { get; set; }
    }
}