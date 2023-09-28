using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;
using HealthClinic_CodeFirst_API.Repositories;
using HealthClinic_CodeFirst_API.ViewModels;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HealthClinic_CodeFirst_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(UsuarioViewModel user)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarEmailSenha(user.Email, user.Senha);

                if (usuarioBuscado != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim("IdTipoDePerfil",usuarioBuscado.Perfil.IdPerfil.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim("CPFdoUsuario",usuarioBuscado.CPF),
                        new Claim(ClaimTypes.Role, usuarioBuscado.Perfil.TipoDePerfil)
                    };

                    //2º - Defiir a chave de acesso ao token
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("healthClinic-chave-autenticacao-webapi-dev"));

                    //3º - Definir as credenciais do token (HEADER)
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //4º - Gerar token
                    var token = new JwtSecurityToken
                    (
                        //emissor do token (O NOME DO projeto)
                        issuer: "HealthClinic-CodeFirst-API",

                        //Destinatário do token (TAMBÉM O NOME DO PROJETO)
                        audience: "HealthClinic-CodeFirst-API",

                        //dados definidos nas claims(informalções)
                        claims: claims,

                        //tempo de expiração do token
                        expires: DateTime.Now.AddMinutes(50),

                        //credenciais do token
                        signingCredentials: creds
                    );

                    //5º - retornar o token criado
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                return Ok(null);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
