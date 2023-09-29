using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext _healthContext;
        public PacienteRepository()
        {
            _healthContext= new HealthContext();
        }
        public void Cadastrar(Paciente pacienteNovo)
        {
            _healthContext.Paciente.Add(pacienteNovo);
            _healthContext.SaveChanges();
        }
    }
}
