using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogosRepository
    {
        public void Cadastrar(JogosDomain _jogocadastrado);
        public List<JogosDomain> Listar();
    }
}
