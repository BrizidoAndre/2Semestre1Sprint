using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;
using System.Runtime;

namespace senai.inlock.webApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        public DateOnly FromDateTime(string data)
        {
            string[] datada= data.Split("T");

            DateOnly datacerta = DateOnly.Parse(datada[0]);

            return datacerta;
        }

        public string StringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes; User Id = sa;pwd = Senai@134; TrustServerCertificate = true";

        public void Cadastrar(JogosDomain _jogocadastrado)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringCadastro = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES (@idEstudio,@nome,@descricao,@dataLancamento,@valor)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(stringCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio",_jogocadastrado.IdEstudio);
                    cmd.Parameters.AddWithValue("@nome", _jogocadastrado.Nome);
                    cmd.Parameters.AddWithValue("@descricao", _jogocadastrado.Descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", _jogocadastrado.DataLancamento);
                    cmd.Parameters.AddWithValue("@valor", _jogocadastrado.Valor);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> listaJogos = new List<JogosDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringListar = "SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome , Descricao, DataLancamento, Valor, Estudio.Nome AS Estudio FROM Jogo LEFT JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(stringListar, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"].ToString()),
                            Valor = Convert.ToDouble(rdr["Valor"]),
                            Estudio = new EstudiosDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                                Nome = rdr["Estudio"].ToString()
                            }
                            
                        };
                        listaJogos.Add(jogo);
                    }
                    con.Close();
                }
                return listaJogos;

            }
        }
    }
}
