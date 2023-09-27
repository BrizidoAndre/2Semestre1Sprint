using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IPlanoDeSaudeRepository
    {
        void Cadastrar(PlanoDeSaude planoNovo);
    }
}
