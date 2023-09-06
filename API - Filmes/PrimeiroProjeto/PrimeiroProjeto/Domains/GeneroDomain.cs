using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjeto.Domains
{
   /// <summary>
   /// Classe que representa a entidade(tabela) gênero
   /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do Gênero é obrigatório")]
        public string Nome { get; set; }
    }
}
