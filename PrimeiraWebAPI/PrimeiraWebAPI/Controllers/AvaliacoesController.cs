using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiraWebAPI.Domain.DTO;
using PrimeiraWebAPI.Services;

namespace PrimeiraWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly AvaliacoesService avaliacoesService;

        public AvaliacoesController(AvaliacoesService avaliacoesService)
        {
            this.avaliacoesService = avaliacoesService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AvaliacaoCreateRequest postModel)
        {

            if (ModelState.IsValid)
            {
                var retorno = avaliacoesService.CadastrarNovo(postModel);

                if (!retorno.Sucesso)
                    return BadRequest(retorno);
                else
                    return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
