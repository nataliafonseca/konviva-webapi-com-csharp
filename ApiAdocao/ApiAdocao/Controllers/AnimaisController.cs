using ApiAdocao.Domain.DTO;
using ApiAdocao.Domain.Entity;
using ApiAdocao.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAdocao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly AnimaisService animaisService;

        public AnimaisController(AnimaisService animaisService)
        {
            this.animaisService = animaisService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AnimalCreateRequest model)
        {
            if (ModelState.IsValid)
            {
                var retorno = this.animaisService.Cadastrar(model);

                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);

                return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return animaisService.ListarTodos();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var retorno = animaisService.PesquisarPorId(id);

            if (!retorno.Sucesso)
                return NotFound(retorno.Mensagem);

            return Ok(retorno.ObjetoRetorno);
        }

        [HttpGet("nome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var retorno = animaisService.PesquisarPorNome(nome);

            if (!retorno.Sucesso)
                return NotFound(retorno.Mensagem);

            return Ok(retorno.ObjetoRetorno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnimalUpdateRequest model)
        {
            if (ModelState.IsValid)
            {
                var retorno = animaisService.Editar(id, model);

                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);

                return Ok(retorno.ObjetoRetorno);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var retorno = animaisService.Deletar(id);

            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);

            return Ok(retorno.ObjetoRetorno);
        }
    }
}
