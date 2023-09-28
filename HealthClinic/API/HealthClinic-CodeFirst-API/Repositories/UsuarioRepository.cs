using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;
using HealthClinic_CodeFirst_API.Utils;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;
        public UsuarioRepository()
        {
            _healthContext= new HealthContext();
        }


        public Usuario BuscarEmailSenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _healthContext.Usuario.Select(z => new Usuario
                {
                    IdUsuario = z.IdUsuario,
                    CPF       = z.CPF,
                    Email     = z.Email,
                    Senha     = z.Senha,
                    Perfil    = new Perfil
                    {
                        IdPerfil = z.IdPerfil,
                        TipoDePerfil = z.Perfil!.TipoDePerfil
                    }
                }).FirstOrDefault(z => z.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Cadastrar(Usuario usuarioNovo)
        {
            try
            {
                usuarioNovo.Senha = Criptografia.GerarHash(usuarioNovo.Senha!);
                _healthContext.Usuario.Add(usuarioNovo);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(string email, string senha)
        {
            try
            {
                Usuario usuarioDeletado = _healthContext.Usuario.FirstOrDefault(z => z.Email == email)!;

                if (usuarioDeletado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioDeletado.Senha!);

                    if (confere)
                    {
                        _healthContext.Usuario.Remove(usuarioDeletado);
                        _healthContext.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
