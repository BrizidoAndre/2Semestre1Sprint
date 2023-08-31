using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using PrimeiroProjeto.Repositories;

namespace PrimeiroProjeto.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult GetUser(string email, string senha)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(email,senha);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return BadRequest("Usuario não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
