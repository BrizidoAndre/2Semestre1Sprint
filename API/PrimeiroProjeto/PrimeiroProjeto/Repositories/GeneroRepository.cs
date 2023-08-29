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
        private string stringConexao = "Data Source = DESKTOP-VLQ1I1C; Initial Catalog = Filmes;  User Id = sa;pwd = Senai@134; TrustServerCertificate = true";






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
        /// Método para atualizar o objeto com base no corpo digitado
        /// </summary>
        /// <param name="genero">O objeto que será usado para encontrar e modificar da lista</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            //Abrindo a conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Criando uma string para atualizar o objeto com base no Id
                string stringUpdate = "UPDATE Genero SET Nome = @nomeAtualizado WHERE IdGenero = @idGenero";

                    //Abrindo a conexão
                    con.Open();

                //Criando o comando
                using (SqlCommand cmd = new SqlCommand(stringUpdate, con))
                {
                    //Colocando o valor do Id o mesmo do objeto do genero
                    cmd.Parameters.AddWithValue("@idGenero", genero.IdGenero);
                    //Colocando o valor do nome o mesmo do objeto genero
                    cmd.Parameters.AddWithValue("@nomeAtualizado", genero.Nome);

                    //Executando o comando de não pesquisa
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Usando a mesma string para realizar o update
                string stringUpdate = "UPDATE Genero SET Nome = @nomeAtualizado WHERE IdGenero = @idGenero";

                    //Abrindo a conexão
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(stringUpdate, con))
                {
                    //Colocando o valor do Id o mesmo do objeto do genero
                    cmd.Parameters.AddWithValue("@idGenero", id);
                    //Colocando o valor do nome o mesmo do objeto genero
                    cmd.Parameters.AddWithValue("@nomeAtualizado", genero.Nome);

                    //Executando o comando de não pesquisa
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
        public GeneroDomain BuscarPorId(int id)
        {
            //Criando a lista de Gêneros
            List<GeneroDomain> listaGenenero = new List<GeneroDomain>();

            GeneroDomain generoBuscado = new GeneroDomain();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string selectAll = "SELECT IdGenero,Nome FROM Genero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain novoGenero = new GeneroDomain()
                        {
                            Nome = rdr["Nome"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };
                        listaGenenero.Add(novoGenero);
                    }

                    generoBuscado = listaGenenero.First(z => z.IdGenero == id);
                }

                return generoBuscado;
            }
        }

        public GeneroDomain AcharPeloId(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Criando uma string que retornará direto o objeto buscado
                string querySelectById = "SELECT IdGenero,Nome FROM Genero WHERE IdGenero = @idGenero";

                //Abrindo a conexão com o banco de dados
                con.Open();

                //Criando o objeto de leitura do banco de dados
                SqlDataReader rdr;

                //Chamando a conexão e chamando a linha de código a ser escrita
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    //colocando a variável na string e dando o mesmo valor do parâmetro do método
                    cmd.Parameters.AddWithValue("@idGenero", id);

                    //Executando a leitura
                    rdr = cmd.ExecuteReader();

                    //A leitura condicional a seguir, nos retornará um valor true. Como o comando no SQL é um valor
                    //com condicional, ele só nos retornará quando um objeto que respeita as condições. Nesse caso o objeto
                    //Que queremos achar. Então é so colocar o objeto buscado igual ao objeto criado e retorná-lo
                    if (rdr.Read())
                    {
                        //Criando o objeto para caso a condicão der certo
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            //Adicionando o valor do Id caso a leitura der certo
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            //Adicionando o valor do Nome caso a leitura der certo
                            Nome = rdr["Nome"].ToString()
                        };
                        //Retornando o objeto criado
                        return generoBuscado;
                    }

                    //Aqui é para o outro caminho também retornar um valor de código, nesse caso se nenhum objeto for encontrado ele retorna nada
                    return null;
                }
            }
        }
    }
}
