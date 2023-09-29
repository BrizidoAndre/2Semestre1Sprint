using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;
using HealthClinic_CodeFirst_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_CodeFirst_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PlanoDeSaudeController : ControllerBase
    {
        private IPlanoDeSaudeRepository _planoDeSaudeRepository;
        public PlanoDeSaudeController()
        {
            _planoDeSaudeRepository = new PlanoDeSaudeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_planoDeSaudeRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PlanoDeSaude planoNovo)
        {
            try
            {
                _planoDeSaudeRepository.Cadastrar(planoNovo);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _planoDeSaudeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, PlanoDeSaude planoModificado)
        {
            try
            {
                _planoDeSaudeRepository.Atualizar(id, planoModificado);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
