namespace senai.inlock.webApi.Domains
{
    public class UsuariosDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TiposUsuariosDomain TipoUsuario { get; set; }
    }
}
