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

        /// <summary>
        /// Método para retornar o login do usuário acertando email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetUser(string email, string senha)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(email,senha);
                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return BadRequest("Email ou senha incorretos.");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
