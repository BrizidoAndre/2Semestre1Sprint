using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Interfaces;
using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Controllers;
using PrimeiroProjeto.Repositories;

namespace PrimeiroProjeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private IFilmesRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilme = _filmeRepository.ListarFilme();
                return Ok(listaFilme);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novofilme)
        {
                try
                {
               
                    _filmeRepository.Cadastrar(novofilme);
                    return StatusCode(201);

                }
                catch (Exception erro)
                {
                    return BadRequest(erro.Message);
                }
            
        }
    }
}

