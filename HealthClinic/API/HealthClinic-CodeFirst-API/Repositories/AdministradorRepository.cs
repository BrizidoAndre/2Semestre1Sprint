using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly HealthContext _healthContext;
        public AdministradorRepository()
        {
            _healthContext= new HealthContext();
        }
        public void Cadastrar(Administrador adminNovo)
        {
            _healthContext.Administrador.Add(adminNovo);
            _healthContext.SaveChanges();
        }
    }
}
