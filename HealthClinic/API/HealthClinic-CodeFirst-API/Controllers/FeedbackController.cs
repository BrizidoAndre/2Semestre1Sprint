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
    public class FeedbackController : ControllerBase
    {
        private IFeedbackRepository _feedbackRepository;
        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpPost]
        public IActionResult Post(Feedback feedback)
        {
            try
            {
                _feedbackRepository.Cadastrar(feedback);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _feedbackRepository.Deletar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método para alterar o feedback
        /// </summary>
        /// <param name="id">O id do feedback alterado</param>
        /// <param name="feedback">O conteúdo a ser modificado</param>
        /// <returns>Um código de sucesso</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Feedback feedback)
        {
            try
            {
                _feedbackRepository.Atualizar(id, feedback);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Um método para listar todos os feedbacks de um paciente
        /// </summary>
        /// <param name="id">O id do paciente</param>
        /// <returns>Uma lista de feedback de um paciente específico</returns>
        [HttpGet("{id}")]
        public IActionResult GetWithId(Guid id)
        {
            try
            {
                return Ok(_feedbackRepository.ListarDeUsuario(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
