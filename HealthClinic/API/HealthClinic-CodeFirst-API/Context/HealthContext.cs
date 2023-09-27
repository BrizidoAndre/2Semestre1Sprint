using HealthClinic_CodeFirst_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_CodeFirst_API.Context
{
    public class HealthContext :DbContext
    {
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<PlanoDeSaude> PlanoDeSaude { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE07-S15; Database= HealthClinic_manha; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
