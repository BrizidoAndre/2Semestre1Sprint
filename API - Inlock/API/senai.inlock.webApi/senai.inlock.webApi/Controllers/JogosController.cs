using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogoRepositoy { get; set; }

        public JogosController()
        {
            _jogoRepositoy = new JogosRepository();
        }


        [HttpGet]
        public IActionResult ListarJogos()
        {
            try
            {
                List<JogosDomain> listaJogos = _jogoRepositoy.Listar();
                return Ok(listaJogos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(JogosDomain jogosCadastrado)
        {
            try
            {
                _jogoRepositoy.Cadastrar(jogosCadastrado);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
