using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domain
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    ///A linha de código acima serve para tornar a propriedade Email única. A declaração ocorre acima da classe
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="O email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="A senha é obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage ="A senha deve conter de 6 a 20 caracteres")]
        public string? Senha { get; set; }
        
        
        
        /// Referência da chave estrangeira (tabela de TiposUsuario)


        [Required(ErrorMessage ="Tipo do usuário é obrigatório")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
