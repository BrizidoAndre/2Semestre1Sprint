using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjeto.Domains
{
    public class UsuarioDomain
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage ="A senha não foi digitada corretamente")]
        public string Senha { get; set; }

        [Required(ErrorMessage ="Você não se identificou como usuário")]
        public bool Permissao { get; set; }
    }
}
