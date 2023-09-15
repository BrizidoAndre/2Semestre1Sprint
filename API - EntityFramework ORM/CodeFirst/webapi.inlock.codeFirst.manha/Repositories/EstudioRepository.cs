using webapi.inlock.codeFirst.manha.Context;
using webapi.inlock.codeFirst.manha.Domain;
using webapi.inlock.codeFirst.manha.Interfaces;

namespace webapi.inlock.codeFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio estudioNovo)
        {
            estudioNovo.IdEstudio = Guid.NewGuid();
            ctx.Estudio.Add(estudioNovo);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            try
            {
                return ctx.Estudio.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Estudio> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
