using webapi.inlock.codeFirst.manha.Domain;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        List<Jogo> ListarTodos();
        void Cadastrar(Jogo JogoNovo);
        void Atualizar(Guid id, Jogo Jogo);
        void Deletar(Guid id);
    }
}
