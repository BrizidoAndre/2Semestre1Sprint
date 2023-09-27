using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(PlanoDeSaude))]
    public class PlanoDeSaude
    {
        [Key]
        public Guid IdPlanoDeSaude { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Um plano de saúde é obrigatório")]
        public string? Titulo { get; set; }
    }
}
