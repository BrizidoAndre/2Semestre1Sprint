using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IPerfilRepository
    {
        void Cadastrar(Perfil perfilNovo);

        List<Perfil> Listar();

        void Deletar(Guid id);

        void Atualizar(Guid id, Perfil perfilAtualizado);
    }
}
