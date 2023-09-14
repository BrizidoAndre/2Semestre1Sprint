using webapi.inlock.codeFirst.manha.Domain;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario (string email, string senha);
        void Cadastrar(Usuario usuarioNovo);
        void Deletar(Guid id);
    }
}
