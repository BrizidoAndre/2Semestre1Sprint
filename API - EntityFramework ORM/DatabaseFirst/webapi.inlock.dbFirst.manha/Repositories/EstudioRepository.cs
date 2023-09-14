using Microsoft.EntityFrameworkCore;
using webapi.inlock.dbFirst.manha.Contexts;
using webapi.inlock.dbFirst.manha.Domains;
using webapi.inlock.dbFirst.manha.Interfaces;

namespace webapi.inlock.dbFirst.manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudioNovo)
        {
            Estudio estudioDeletado = ctx.Estudios.Find(id);

            if (estudioDeletado != null)
            {
                estudioDeletado.Nome = estudioNovo.Nome;
            }

            ctx.Estudios.Update(estudioDeletado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(z => z.IdEstudio == id);
        }

        public void Cadastrar(Estudio estudioNovo)
        {
            estudioNovo.IdEstudio = Guid.NewGuid();
            ctx.Add(estudioNovo);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioDeletado = ctx.Estudios.Find(id);
            ctx.Estudios.Remove(estudioDeletado);
            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
