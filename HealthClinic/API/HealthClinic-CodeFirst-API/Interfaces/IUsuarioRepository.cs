using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuarioNovo);

        void Deletar(string email, string senha);

        Usuario BuscarEmailSenha(string email,string senha);
    }
}
