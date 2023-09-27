using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente pacienteNovo);
    }
}
