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
            //DEclara a conxão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que será executada
                string queryInsert = $"INSERT INTO Genero(Nome) VALUES('{novoGenero.Nome}')";

                //Abertura da conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Executar a query (queryInsert)
                    cmd.ExecuteReader();

                }
            }
        }

        public void Deletar(int IdGenero)
        {
            throw new NotImplementedException();
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
