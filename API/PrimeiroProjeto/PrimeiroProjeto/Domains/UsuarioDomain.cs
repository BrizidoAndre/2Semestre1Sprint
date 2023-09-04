using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjeto.Domains
{
    public class UsuarioDomain
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength = 3,ErrorMessage ="A senha deve ter de 3 a 20 caracteres")]

        [Required(ErrorMessage ="A senha não foi digitada corretamente")]
        public string Senha { get; set; }

        [Required(ErrorMessage ="Você não se identificou como usuário")]
        public string Permissao { get; set; }
        //A permissão é um falor booleano. Para resumir se o valor é false, o usuário tem acesso comum, se o valor é true, ele tem acesso ilimitado.

        public int IdUsuario { get; set; }

    }
}
