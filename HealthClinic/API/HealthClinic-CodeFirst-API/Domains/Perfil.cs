using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_CodeFirst_API.Domains
{
    [Table(nameof(Perfil))]
    public class Perfil
    {
        [Key]
        public Guid IdPerfil { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage ="Um tipo de perfil é obrigatório")]
        public string? TipoDePerfil { get; set; }

    }
}
