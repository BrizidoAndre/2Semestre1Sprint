using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;
using HealthClinic_CodeFirst_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClinic_CodeFirst_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PerfilController : ControllerBase
    {
        private IPerfilRepository _perfilRepository;
        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_perfilRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Perfil perfilNovo)
        {
            try
            {
                _perfilRepository.Cadastrar(perfilNovo);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _perfilRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Perfil perfilAtualizado)
        {
            try
            {
                _perfilRepository.Atualizar(id, perfilAtualizado);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
