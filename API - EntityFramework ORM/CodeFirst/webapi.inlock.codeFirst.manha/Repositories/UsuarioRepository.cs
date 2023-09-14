using webapi.inlock.codeFirst.manha.Context;
using webapi.inlock.codeFirst.manha.Domain;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Utils;

namespace webapi.inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variável privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositório
        /// Toda vez que o repositório for instanciado,
        /// Ele terá acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }


        public Usuario BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuarioNovo)
        {
            try
            {
                usuarioNovo.Senha = Criptografia.GerarHash(usuarioNovo.Senha!);

                ctx.Usuario.Add(usuarioNovo);
                ctx.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
