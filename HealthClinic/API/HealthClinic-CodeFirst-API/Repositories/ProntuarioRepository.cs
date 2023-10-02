using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly HealthContext _healthContext;
        public ProntuarioRepository()
        {
            _healthContext= new HealthContext();
        }
        public void Cadatrar(Prontuario prontuario)
        {
            _healthContext.Prontuario.Add(prontuario);
            _healthContext.SaveChanges();
        }
    }
}
