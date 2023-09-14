using webapi.inlock.codeFirst.manha.Domain;

namespace webapi.inlock.codeFirst.manha.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();
        List<Estudio> ListarTodos();
        void Cadastrar(Estudio estudioNovo);
        void Atualizar(Guid id, Estudio estudio);
        void Deletar(Guid id);


    }
}
