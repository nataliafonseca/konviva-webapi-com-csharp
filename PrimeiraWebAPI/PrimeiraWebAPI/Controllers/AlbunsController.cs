using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraWebAPI.Domain.DTO;
using PrimeiraWebAPI.Domain.Entity;
using PrimeiraWebAPI.Services;


namespace PrimeiraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbunsController : ControllerBase
    {
        private readonly AlbunsService albumService;

        public AlbunsController(AlbunsService albumService)
        {
            this.albumService = albumService;
        }

        [HttpGet]
        public IEnumerable<AlbumResponse> Get()
        {
            return albumService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = albumService.PesquisarPorId(id);

            if (!retorno.Sucesso)
                return NotFound(retorno.Mensagem);

            return Ok(retorno.ObjetoRetorno);

        }

        [HttpGet("nome/{nomeParam}")]
        public IActionResult GetByNome(string nomeParam)
        {
            var retorno = albumService.PesquisarPorNome(nomeParam);

            if (!retorno.Sucesso)
                return NotFound(retorno.Mensagem);

            return Ok(retorno.ObjetoRetorno);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlbumCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = this.albumService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                {
                    return BadRequest(retorno.Mensagem);
                }
                return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlbumUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = albumService.Editar(id, putModel);

                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);

                return Ok(retorno.ObjetoRetorno);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = albumService.Deletar(id);

            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok(retorno.ObjetoRetorno);
        }
    }
}
