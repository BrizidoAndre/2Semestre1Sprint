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
    public class UsuariosController : ControllerBase
    {
        IUsuariosRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuariosDomain usuario)
        {
            try
            {
                UsuariosDomain usuarioBusca = _usuarioRepository.Login(usuario.Email, usuario.Senha);

                if (usuarioBusca != null)
                {
                    return Ok(usuarioBusca);
                }
                return BadRequest("Usuario não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
