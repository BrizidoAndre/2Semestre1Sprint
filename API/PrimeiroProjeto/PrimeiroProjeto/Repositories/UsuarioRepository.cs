using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using System.Data.SqlClient;
//A using acima é chamada automaticamente quando instanciamos um comando SQL
using System.Reflection;

namespace PrimeiroProjeto.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes; User Id = sa;pwd = Senai@134; TrustServerCertificate = true";
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringBuscarId = "SELECT Email, Senha, Permissao FROM Usuario WHERE Email = @email AND Senha = @senha";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(stringBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuariobusca = new UsuarioDomain()
                        {
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };
                            return usuariobusca;
                    }
                    return null;
                }
            }
        }
    }
}
