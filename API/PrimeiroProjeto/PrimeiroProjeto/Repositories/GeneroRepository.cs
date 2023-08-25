using PrimeiroProjeto.Domains;
using PrimeiroProjeto.Interfaces;
using System.Data.SqlClient;
using System.Reflection;

namespace PrimeiroProjeto.Repositories
{
    public class GeneroRepository : Interfaces.IGeneroRepository
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
        private string stringConexao = "Data Source = NOTE07-S15; Initial Catalog = Filmes;  User Id = sa;pwd = Senai@134; TrustServerCertificate = true";
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

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";


                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parâmetro @Nome e liga ele ao nome do objeto
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abertura da conexão com o banco de dados
                    con.Open();

                    //Executar a query (queryInsert)
                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Método para deletar o objeto
        /// </summary>
        /// <param name="IdGenero">Através do Id, poderemos identificar qual método vamos deletar da tabela gênero</param>
        public void Deletar(int IdGenero)
        {
            //Declarando a conexão do banco com a string
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declarando o comando que deletará o id selecionado
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdDeletado";


                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdDeletado", IdGenero);

                    con.Open();

                    //Executar a query (queryDelete)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos generos
        /// </summary>
        /// <returns>Lista de objetos (gêneros) </returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos do tipo gênero
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query qyeserpa executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            //Atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };
                        //Adiciona cada objeto dentro da lista
                        listaGenero.Add(genero);
                    }
                }
            }

            //Retorna a lista de gênero
            return listaGenero;
        }
    }
}
