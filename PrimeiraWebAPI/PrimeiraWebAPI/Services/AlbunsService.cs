using Microsoft.EntityFrameworkCore;
using PrimeiraWebAPI.DAL;
using PrimeiraWebAPI.Domain.DTO;
using PrimeiraWebAPI.Domain.Entity;
using PrimeiraWebAPI.Services.Base;

namespace PrimeiraWebAPI.Services
{
    public class AlbunsService
    {
        private readonly AppDbContext _dbContext;

        public AlbunsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<Album> CadastrarNovo(AlbumCreateRequest model)
        {
            // RN: Aceita apenas albuns lançados entre 1950 e o ano atual.
            if (!model.AnoLancamento.HasValue || model.AnoLancamento < 1950 || model.AnoLancamento > DateTime.Today.Year)
            {
                return new ServiceResponse<Album>("Somente é possível cadastrar albuns lançados entre 1950 e o ano atual");
            }

            Album novoAlbum = new()
            {
                Nome = model.Nome,
                Artista = model.Artista,
                AnoLancamento = model.AnoLancamento.Value
            };

            _dbContext.Add(novoAlbum);
            _dbContext.SaveChanges();

            return new ServiceResponse<Album>(novoAlbum);
        }

        public List<Album> ListarTodos()
        {
            // SELECT * FROM Albuns;
            return _dbContext.Albuns.ToList();
        }

        public ServiceResponse<Album> PesquisarPorId(int id)
        {
            // SELECT TOP 1 * FROM Albuns WHERE Albuns.IdAlbum == id;
            var resultado = _dbContext.Albuns.FirstOrDefault(album => album.IdAlbum == id);

            if (resultado == null)
                return new ServiceResponse<Album>("Album não encontrado!");

            return new ServiceResponse<Album>(resultado);
        }

        public ServiceResponse<Album> PesquisarPorNome(string nome)
        {
            // SELECT TOP 1 * FROM Albuns WHERE Albuns.Nome == nome;
            var resultado = _dbContext.Albuns.FirstOrDefault(album => album.Nome == nome);

            if (resultado == null)
                return new ServiceResponse<Album>("Album não encontrado!");

            return new ServiceResponse<Album>(resultado);
        }

        public ServiceResponse<Album> Editar(int id, AlbumUpdateRequest model)
        {
            var resultado = _dbContext.Albuns.FirstOrDefault(album => album.IdAlbum == id);

            if (resultado == null)
                return new ServiceResponse<Album>("Album não encontrado!");

            resultado.Artista = model.Artista;

            _dbContext.Albuns.Add(resultado).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<Album>(resultado);
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = _dbContext.Albuns.FirstOrDefault(album => album.IdAlbum == id);

            if (resultado == null)
                return new ServiceResponse<bool>("Album não encontrado!");

            _dbContext.Albuns.Remove(resultado);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }
    }
}
