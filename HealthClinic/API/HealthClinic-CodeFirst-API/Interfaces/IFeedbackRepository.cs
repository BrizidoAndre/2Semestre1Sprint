using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback feedbackNovo);
        List<Feedback> ListarDeUsuario(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, Feedback feedbackAlterado);
    }
}
