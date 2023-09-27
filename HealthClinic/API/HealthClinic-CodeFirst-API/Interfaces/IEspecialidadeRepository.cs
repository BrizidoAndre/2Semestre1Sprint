using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidadeNova);
        List<Especialidade> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Especialidade especilidadeAlterada);
    }
}
