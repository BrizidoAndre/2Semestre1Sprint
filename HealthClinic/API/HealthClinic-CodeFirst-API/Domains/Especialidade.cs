using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; }

        [Column(TypeName ="VARCHAR(80)")]
        [Required(ErrorMessage ="A especialidade é obrigatória")]
        public string? Titulo { get; set; }
    }
}
