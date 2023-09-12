using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
                    //Caso o usuário for encontrado, prossegue para a criação do token

                    //1º - Definir as informações (Claims) que serão fornecidos no token (PAYLOAD)
                    var claims = new[]
                    {
                    //Formato da claim
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBusca.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBusca.Email),
                    new Claim(ClaimTypes.Role,usuarioBusca.TipoUsuario.Titulo.ToString()),

                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada","Valor da Claim Personalizada")
                };

                    //2º - Defiir a chave de acesso ao token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-exercicio"));

                    //3º - Definir as credenciais do token (HEADER)
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º - Gerar token
                    var token = new JwtSecurityToken
                    (
                        //emissor do token (O NOME DO projeto)
                        issuer: "senai.inlock.webApi",

                        //Destinatário do token (TAMBÉM O NOME DO PROJETO)
                        audience: "senai.inlock.webApi",

                        //dados definidos nas claims(informações)
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
                return BadRequest("Usuario não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
