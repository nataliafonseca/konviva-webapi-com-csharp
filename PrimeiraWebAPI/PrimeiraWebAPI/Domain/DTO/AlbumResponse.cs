using PrimeiraWebAPI.Domain.Entity;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class AlbumResponse
    {
        public int IdAlbum { get; set; }
        public string Nome { get; set; }
        public string Artista { get; set; }
        public int AnoLancamento { get; set; }
        public List<AvaliacaoResponse> Avaliacoes { get; set; }
        public String AvaliacaoMedia { get; set; }

        public AlbumResponse(Album album)
        {
            IdAlbum = album.IdAlbum;
            Nome = album.Nome;
            Artista = album.Artista;
            AnoLancamento = album.AnoLancamento;

            if (album.Avaliacoes != null && album.Avaliacoes.Any())
            {
                Avaliacoes = new List<AvaliacaoResponse>();
                Avaliacoes.AddRange(album.Avaliacoes.Select(x => new AvaliacaoResponse(x)));

                double media = Avaliacoes.Average(avaliacao => avaliacao.Nota);

                AvaliacaoMedia = media.ToString("F2");
            }
        }
    }
}
