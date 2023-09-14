using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.manha.Domain;

namespace webapi.inlock.codeFirst.manha.Context
{
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Define as opções de construção do banco (String Conexão)
        /// </summary>
        /// <param name="optionBuilder">O tipo de dado para a criação da string de conexão</param>

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=NOTE07-S15; Database=inlock_games_CodeFirst_manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionBuilder);
        }
    }
}
