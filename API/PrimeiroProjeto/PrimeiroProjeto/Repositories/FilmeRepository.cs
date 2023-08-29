using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

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
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringPost = "INSERT INTO Filme(IdGenero,Titulo) VALUES(@idGenero,@filmeTitulo)";

                using (SqlCommand cmd = new SqlCommand(stringPost,con))
                {
                    cmd.Parameters.AddWithValue("idGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@filmeTitulo", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

            
        }

        public void Deletar(int IdFilme)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarFilme()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string stringQuery = "SELECT IdFilme, Filme.IdGenero, Genero.Nome, Titulo FROM Filme LEFT JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(stringQuery, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            Titulo = rdr["Titulo"].ToString(),
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Genero = new GeneroDomain()
                            {
                                Nome = rdr["Nome"].ToString(),
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])
                            }
                        };

                        listaFilme.Add(filme);
                    }
                }
            }
            return listaFilme;

        }
    }
}

