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
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository=new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Cadastrar(especialidade);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Especialidade especialidade)
        {
            try
            {
                _especialidadeRepository.Atualizar(id, especialidade);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
