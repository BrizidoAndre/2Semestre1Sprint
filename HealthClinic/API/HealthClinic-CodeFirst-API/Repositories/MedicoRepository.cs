using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext _healthContext;
        public MedicoRepository()
        {
            _healthContext= new HealthContext();
        }

        public void Cadastrar(Medico medicoNovo)
        {
            _healthContext.Medico.Add(medicoNovo);
            _healthContext.SaveChanges();
        }
    }
}
