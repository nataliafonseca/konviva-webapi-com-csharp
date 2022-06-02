using PrimeiraWebAPI.DAL;
using PrimeiraWebAPI.Domain.DTO;
using PrimeiraWebAPI.Domain.Entity;
using PrimeiraWebAPI.Services.Base;

namespace PrimeiraWebAPI.Services
{
    public class AvaliacoesService
    {
        private readonly AppDbContext _dbContext;

        public AvaliacoesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<AvaliacaoResponse> CadastrarNovo(AvaliacaoCreateRequest model)
        {
            var resultado = _dbContext.Albuns.FirstOrDefault(album => album.IdAlbum == model.IdAlbum);

            if (resultado == null)
                return new ServiceResponse<AvaliacaoResponse>("Album não encontrado");

            if (model.Nota < 1 || model.Nota > 5)
                return new ServiceResponse<AvaliacaoResponse>("A nota da avaliação deve ser um número entre 1 e 5");

            var novaAvaliacao = new Avaliacao()
            {
                Nota = model.Nota,
                Comentario = model.Comentario,
                IdAlbum = model.IdAlbum
            };

            _dbContext.Add(novaAvaliacao);
            _dbContext.SaveChanges();

            var retorno = new AvaliacaoResponse(novaAvaliacao);
            return new ServiceResponse<AvaliacaoResponse>(retorno);

        }
    }
}
