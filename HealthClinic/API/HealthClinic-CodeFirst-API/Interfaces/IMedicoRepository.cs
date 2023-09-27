using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IMedicoRepository
    {
        void Cadastrar(Medico medicoNovo);
    }
}
