using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuariosRepository
    {
        public UsuariosDomain Login(string _email, string _senha);
    }
}
