using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Administrador))]
    public class Administrador
    {
        [Key]
        public Guid IdAdministrador { get; set; }

        [Column(TypeName ="VARCHAR(80)")]
        [Required(ErrorMessage ="O nome do administrador é obrigatório")]
        public string? Nome { get; set; }

        //REF.table Usuario
        [Required(ErrorMessage ="O tipo de usuario é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
