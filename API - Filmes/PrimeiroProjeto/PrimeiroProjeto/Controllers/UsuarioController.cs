using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using PrimeiroProjeto.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public IActionResult GetUser(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBusca = _usuarioRepository.Login(usuario.Email, usuario.Senha);
                if (usuario != null)
                {
                    //Caso o usuário for encontrado, prossegue para a criação do token

                    //1º - Definir as informações (Claims) que serão fornecidos no token (PAYLOAD)
                    var claims = new[]
                    {
                    //Formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBusca.IdUsuario.ToString()),
                    //Muito Cuidado aqui, as claims não podem se repetir de jeito algum. DOIS JTI DÁ PROBLEMA DE TOKEN INVÁLIDO
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBusca.Email),
                    new Claim(ClaimTypes.Role,usuarioBusca.Permissao.ToString()),

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                    //2º - Defiir a chave de acesso ao token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                    //3º - Definir as credenciais do token (HEADER)
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º - Gerar token
                    var token = new JwtSecurityToken
                    (
                        //emissor do token (O NOME DO projeto)
                        issuer: "PrimeiroProjeto",

                        //Destinatário do token (TAMBÉM O NOME DO PROJETO)
                        audience: "PrimeiroProjeto",

                        //dados definidos nas claims(informalções)
                        claims: claims,

                        //tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(5),

                        //credenciais do token
                        signingCredentials: creds
                    );

                    //5º - retornar o token criado
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
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
