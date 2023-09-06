using Microsoft.AspNetCore.Authorization;
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
    //Este autorize serve paraidentificar quais usuarios tem acesso ao método

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
        //MUITA ATENÇÃO AQUI O MÉTODO SÓ PODE SER PROTEGIDO ATRAVÉS DESSE COMANDO
        //USANDO O AUTHORIZED Roles vc consegue determinar quais valores (que dentro dele devem ser string) podem realizar o método
        //relembrando que meu Roles está diretamente ligado com a minha coluna permissão dentro da tabela de dados e por ser um valor bit
        //só existem dois valores possíveis. Caso a coluna fosse string eu precisaria digitar exatamente como está na database
        [Authorize(Roles = "True, False")]
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
        [Authorize(Roles = "True, False")]
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
        [Authorize(Roles = "True")]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo ao chamada para o método cadastrar passando o objeto como parâmetro
                if (novoGenero.Nome == null || novoGenero.Nome == "string")
                {
                    return NotFound("É necessário colocar um nome");
                }
                else
                {
                    _generoRepository.Cadastrar(novoGenero);
                    return StatusCode(201);
                }

                //Retorna oum status code 201 - Created
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
        [Authorize(Roles = "True")]
        public IActionResult Delete(int IdGenero)
        {
            try
            {
                if (IdGenero == 0)
                {
                    return NotFound("Um id deve ser colocado!");
                }
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
        [Authorize(Roles = "True")]
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
        /// <summary>
        /// Método para pesquisar o id do gênero e então modificar o corpo
        /// </summary>
        /// <param name="IdGenero">O id do genero a ser buscado</param>
        /// <param name="generoNovo">O objeto que será alterado</param>
        /// <returns></returns>
        [HttpPut("{IdGenero}")]
        [Authorize(Roles = "True")]
        public IActionResult Put(int IdGenero, GeneroDomain generoNovo)
        {
            try
            {
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
