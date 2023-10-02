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
    public class AdministradorController : ControllerBase
    {
        private IAdministradorRepository _admRepository;
        public AdministradorController()
        {
            _admRepository = new AdministradorRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Administrador admNovo)
        {
            try
            {
                _admRepository.Cadastrar(admNovo);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
