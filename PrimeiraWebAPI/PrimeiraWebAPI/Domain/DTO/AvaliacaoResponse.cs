using PrimeiraWebAPI.Domain.Entity;

namespace PrimeiraWebAPI.Domain.DTO
{
    public class AvaliacaoResponse
    {
        public int IdAvaliacao { get; set; }
        public int IdAlbum { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; }

        public AvaliacaoResponse(Avaliacao avaliacao)
        {
            IdAvaliacao = avaliacao.IdAvaliacao;
            IdAlbum = avaliacao.IdAlbum;
            Nota = avaliacao.Nota;
            Comentario = avaliacao.Comentario;
        }
    }
}
