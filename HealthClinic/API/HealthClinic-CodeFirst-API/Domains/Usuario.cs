using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(CPF), IsUnique =true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(250)")]
        [Required(ErrorMessage ="Um email é obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="A senha é obrigatória")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "Um CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve obrigatoriamente conter 11 caracteres")]
        public string? CPF { get; set; }

        [Required(ErrorMessage ="É necessário inserir o tipo do perfil")]
        public Guid IdPerfil { get; set; }

        [ForeignKey(nameof(IdPerfil))]
        public Perfil? Perfil { get; set; }
    }
}
