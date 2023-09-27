using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext _healthContext;
        public UsuarioRepository()
        {
            _healthContext= new HealthContext();
        }

        public void Alterar(Guid id, Usuario usuarioModificado)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuarioNovo)
        {
            try
            {
                _healthContext.Usuario.Add(usuarioNovo);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
