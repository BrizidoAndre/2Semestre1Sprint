using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(80)")]
        [Required(ErrorMessage ="Um endereco é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName ="VARCHAR(14)")]
        [Required(ErrorMessage ="O CPNJ é obrigatório")]
        [StringLength(14, ErrorMessage ="O CNPJ deve conter obrigatoriamente 14 caracteres")]
        public string? CNPJ { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="A razão social é obrigatória")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName ="TIME")]
        [Required(ErrorMessage ="O horário de abertura é obrigatório")]
        public string? HorarioAbertura { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "O horário de fechamento é obrigatório")]
        public string? HorarioEncerramento { get; set; }
    }
}
