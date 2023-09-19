using apiweb.eventplus.manha.Domains;
using apiweb.eventplus.manha.Interfaces;
using apiweb.eventplus.manha.Repositories;
using apiweb.eventplus.manha.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiweb.eventplus.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult GetEmailSenha(LoginViewModel usuario)
        {
            try
            {
                Usuario usuariobuscado = _usuarioRepository.BuscarPorEmailSenha(usuario.Email, usuario.Senha);
                if (usuariobuscado != null)
                {
                    return Ok(usuariobuscado);
                }
                return Ok(null);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
