using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;

namespace PrimeiroProjeto.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
    /// <summary>
    ///  String de conexão com o banco de dados que recebe os seguintes parãmetros:
    ///  Data Source : Nome do servidor
    ///  Initia Catalog : Nome do banco de dados
    ///  Autenticação:
    ///     -Windows : Integrated Security = true
    ///     -SQLServer: User Id = sa; Pwd = Senhadoservidor
    ///     
    /// </summary>
        private string stringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filme;  User Id = sa; pwd = Senai@134; TrustServerCertificate = true";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
