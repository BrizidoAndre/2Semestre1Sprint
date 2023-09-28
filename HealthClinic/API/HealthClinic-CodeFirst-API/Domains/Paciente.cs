using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName ="VARCHAR(80)")]
        [Required(ErrorMessage ="O nome do paciente é obrigatório")]
        public string? Name { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="O sexo do paciente é obrigatório")]
        public bool? Sexo { get; set; }
        //Aqui temos um valor em bit, se for 0 o paciente é mulher e se for 1 o paciente é homem

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataDeNascimento { get; set; }

        [Required(ErrorMessage ="O tipo do usuário é obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage ="Um plano de saúde deve ser inserido")]
        public Guid IdPlanoDeSaude { get; set; }

        [ForeignKey(nameof(IdPlanoDeSaude))]
        public PlanoDeSaude? PlanoDeSaude { get; set; }
    }
}
