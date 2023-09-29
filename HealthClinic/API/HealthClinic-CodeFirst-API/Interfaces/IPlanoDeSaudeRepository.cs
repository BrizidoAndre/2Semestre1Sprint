using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IPlanoDeSaudeRepository
    {
        void Cadastrar(PlanoDeSaude planoNovo);
        void Deletar(Guid id);
        void Atualizar(Guid id, PlanoDeSaude planoNovo);
        List<PlanoDeSaude> Listar();
    }
}
