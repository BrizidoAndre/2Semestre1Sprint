using apiweb.eventplus.manha.Contexts;
using apiweb.eventplus.manha.Domains;
using apiweb.eventplus.manha.Interfaces;

namespace apiweb.eventplus.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext= new EventContext();
        }
        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);
            _eventContext.SaveChanges();
        }
    }
}
