using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext _healthContext;
        public ConsultaRepository()
        {
            _healthContext= new HealthContext();
        }

        public void Atualizar(Guid id, Consulta consulta)
        {
            Consulta z = _healthContext.Consulta.FirstOrDefault(z => z.IdConsulta== id)!;

            z.IdClinica = consulta.IdClinica;
            z.HorarioDaConsulta = consulta.HorarioDaConsulta;
            z.Descricao = consulta.Descricao;
            z.Confirmacao = consulta.Confirmacao;
            z.IdAdministrador = consulta.IdAdministrador;
            z.IdMedico = consulta.IdMedico;
            z.IdPaciente = consulta.IdPaciente;

            _healthContext.Consulta.Update(z);

            _healthContext.SaveChanges();
        }

        public void Cadastrar(Consulta consultaNova)
        {
            _healthContext.Consulta.Add(consultaNova);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Consulta consultaDeletada = _healthContext.Consulta.FirstOrDefault(z => z.IdConsulta == id)!;

            if (consultaDeletada!=null)
            {
                _healthContext.Consulta.Remove(consultaDeletada);
                _healthContext.SaveChanges();
            }
        }

        public List<Consulta> ListarDeMedico(Guid idMedico)
        {
            return _healthContext.Consulta.Where(z => z.IdMedico== idMedico).ToList();
        }

        public List<Consulta> ListarDePaciente(Guid idPaciente)
        {
            return _healthContext.Consulta.Where(z => z.IdPaciente== idPaciente).ToList();
        }
    }
}
