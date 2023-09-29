using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Context;

namespace HealthClinic_CodeFirst_API.ViewModels
{
    public class PacienteViewModel
    {
        private readonly HealthContext _healthContext;
        public PacienteViewModel()
        {
            _healthContext= new HealthContext();
        }
        private Guid idPaciente = Guid.Parse("9501E1A9-63CB-4B4D-BC97-90008143363E")
        {
            IdPerfil = z.IdPerfil
        }).FirstOrDefault(z => z.TipoDePerfil == "Paciente");

        [Column(TypeName = "VARCHAR(80)")]
        [Required(ErrorMessage = "O nome do paciente é obrigatório")]
        public string? Name { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "O sexo do paciente é obrigatório")]
        public bool? Sexo { get; set; }
        //Aqui temos um valor em bit, se for 0 o paciente é mulher e se for 1 o paciente é homem

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        public DateOnly? DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O tipo do usuário é obrigatório")]
        public Guid IdUsuario { get; set; } 

        [Required(ErrorMessage = "Um plano de saúde deve ser inserido")]
        public Guid IdPlanoDeSaude { get; set; }
        


    }
}
