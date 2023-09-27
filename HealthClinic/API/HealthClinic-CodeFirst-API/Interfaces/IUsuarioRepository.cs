using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuarioNovo);

        void Alterar(Guid id, Usuario usuarioModificado);
    }
}
