using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(80)")]
        [Required(ErrorMessage ="O nome do médico é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage ="Uma CRM deve ser digitada")]
        [StringLength(11, ErrorMessage ="A CRM deve conter 11 dígitos")]
        public string? CRM { get; set; }



        //ref.table Usuario = FK
        [Required(ErrorMessage ="O tipo de usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        //ref.table Especialidade = FK
        [Required(ErrorMessage ="A especialidade é obrigatória")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }
    }
}
