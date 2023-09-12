using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes; User Id = sa;pwd = Senai@134; TrustServerCertificate = true";
        public UsuariosDomain Login(string _email, string _senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringLogin = "SELECT IdUsuario, Email, Senha, Usuario.IdTipoUsuario as IdTypeUser, Titulo FROM Usuario LEFT JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdTipoUsuario WHERE Email = @emailBusca AND Senha = @senhaBusca";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(stringLogin, con))
                {
                    cmd.Parameters.AddWithValue("@emailBusca", _email);
                    cmd.Parameters.AddWithValue("@senhaBusca", _senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuario = new UsuariosDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTypeUser"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            TipoUsuario = new TiposUsuariosDomain()
                            {
                                Titulo = rdr["Titulo"].ToString(),
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTypeUser"])
                            }
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
