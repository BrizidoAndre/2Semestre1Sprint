using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domain
{
    /// <summary>
    /// Classe que representa a entidade jogo
    /// </summary>
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage ="A descricao é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage ="A data de lançamento é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage ="Preço do jogo é obrigatório")]
        public decimal Preco { get; set; }

        //Aqui é feito para criar uma chave estrangeria na classe. Note que criamos a propriedade IdEstudio do tipo GUID e chamamos ela
        //em outra propriedade, esta de tipo Estudio.

        [Required(ErrorMessage ="Um jogo deve ter um estúdio")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
