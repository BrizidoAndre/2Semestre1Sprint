using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="A descrição da consulta é obrigatória")]
        public string? Descricao { get; set; }


        [Column(TypeName ="DATETIME")]
        [Required(ErrorMessage ="A data da consulta é obrigatória")]
        public DateTime? HorarioDaConsulta { get; set; }

        //Uma propriedade bool de confirmação. Se o valor for 0 ou false a consulta foi cancelada, se o valor for 1 ou true a consulta está confirmada
        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="É preciso inserir a confirmacao")]
        public bool Confirmacao { get; set; }

        // re. table Clinica = FK

        [Required(ErrorMessage ="É obrigatório inserir uma clínica")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }

        // re. table Administrador = FK

        [Required(ErrorMessage = "É obrigatório inserir um administrador")]
        public Guid IdAdministrador { get; set; }

        [ForeignKey(nameof(IdAdministrador))]
        public Administrador? Administrador { get; set; }

        // re. table Medico = FK

        [Required(ErrorMessage = "É obrigatório inserir um Médico")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        // re. table Paciente = FK

        [Required(ErrorMessage = "É obrigatório inserir um Paciente")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

    }
}
