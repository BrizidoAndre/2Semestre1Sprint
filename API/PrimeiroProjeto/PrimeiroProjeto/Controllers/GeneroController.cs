using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using PrimeiroProjeto.Repositories;

namespace PrimeiroProjeto.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //Domínio/API/nomeController
    //Ex: http://localhost:5000/api/GeneroController
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Método controlador que herda da controller base
    //Onde será criado os Endpoint (rotas)
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _heneroRepository qye irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório e retorna a resposta para o usuário(front-end)
        /// </summary>
        /// <returns> Resposta para o usuário(front-end)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(listaGenero);

            }
            catch (Exception erro)
            {
                //Aqui retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        //[HttpGet("{IdGenero}")]
        //public IActionResult Get(int IdGenero)
        //{
        //    try
        //    {
        //        GeneroDomain generoBuscado = _generoRepository.BuscarPorId(IdGenero);

        //        return Ok(generoBuscado);
        //    }
        //    catch (Exception erro)
        //    {

        //        return BadRequest(erro.Message);
        //    }
        //}

        /// <summary>
        /// Método que encontra o objeto através do Id
        /// </summary>
        /// <param name="IdGenero">O Id que nos retornará o objeto</param>
        /// <returns>O objeto buscado</returns>
        [HttpGet("{IdGenero}")]
        public IActionResult GetWithId(int IdGenero)
        {
            try
            {
                GeneroRepository _genero = new GeneroRepository();
                GeneroDomain generoBuscado = _genero.AcharPeloId(IdGenero);

                if (generoBuscado == null)
                {
                    return NotFound("Nenhum gênero foi encontrado!");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona método de cadastro de gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>status code 201 (created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo ao chamada para o método cadastrar passando o objeto como parâmetro
                _generoRepository.Cadastrar(novoGenero);

                //Retorna oum status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Método para deletar o elemento do banco de dados
        /// </summary>
        /// <param name="IdGenero">Parâmetro que busca o id a ser deletado</param>
        /// <returns>Retorna a conclusão do delete</returns>
        [HttpDelete("{IdGenero}")]
        public IActionResult Delete(int IdGenero)
        {
            try
            {
                _generoRepository.Deletar(IdGenero);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Método para atualizar o objeto modificando o corpo em si
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPatch("{IdGenero}")]
        public IActionResult Patch(int IdGenero, GeneroDomain generoNovo)
        {
            try
            {
                GeneroRepository _genero = new GeneroRepository();
                generoNovo = _genero.AcharPeloId(IdGenero);
                _generoRepository.AtualizarIdUrl(IdGenero, generoNovo);

                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
