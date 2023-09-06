using PrimeiroProjeto.Domains;

namespace PrimeiroProjeto.Interfaces
{
    public interface IUsuarioRepository
    {
        public UsuarioDomain Login(string email, string senha);
    }
}
