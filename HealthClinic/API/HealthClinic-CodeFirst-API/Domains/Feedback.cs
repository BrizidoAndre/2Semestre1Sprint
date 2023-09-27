using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Um comentário deve ser digitado")]
        public string? Comentario { get; set; }

        //ref.table Paciente = FK
        [Required(ErrorMessage ="Um paciente deve estar ligado ao comentário")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        //ref.table Consulta = FK
        [Required(ErrorMessage ="O comentário deve estar ligado a uma consulta")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
