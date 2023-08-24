using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;

namespace PrimeiroProjeto.Repositories
{
    public class FilmeRepository : Interfaces.IFilmesRepository
    {
        private string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes; User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void AtualizarIdCorpo(FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FilmeDomain Filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarFilme()
        {
            throw new NotImplementedException();
        }
    }
}
