using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.manha.Domain;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Repositories;

namespace webapi.inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("json/application")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;
        public EstudioController()
        {
            _estudioRepository= new EstudioRepository();
        }

        [HttpGet]
        public ActionResult List()
        {
            try
            {

                return Ok(_estudioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
