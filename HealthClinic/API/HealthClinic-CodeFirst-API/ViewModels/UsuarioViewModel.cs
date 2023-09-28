using System.ComponentModel.DataAnnotations;

namespace HealthClinic_CodeFirst_API.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="É obrigatório inserir um email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="É obrigatório inserir a senha")]
        [StringLength(60, MinimumLength = 6, ErrorMessage ="A senha deve conter mais de 6 caracteres")]
        public string Senha { get; set; }
    }
}
