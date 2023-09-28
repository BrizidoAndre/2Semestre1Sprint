using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext _healthContext;
        public ClinicaRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Clinica c)
        {
            try
            {
                Clinica clinicaVelha = _healthContext.Clinica.FirstOrDefault(z => z.IdClinica== id)!;

                clinicaVelha.RazaoSocial = c.RazaoSocial;
                clinicaVelha.HorarioEncerramento = c.HorarioEncerramento;
                clinicaVelha.HorarioAbertura = c.HorarioAbertura;
                clinicaVelha.CNPJ = c.CNPJ;
                clinicaVelha.Endereco = c.Endereco;

                _healthContext.Clinica.Update(clinicaVelha);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Clinica clinicaNova)
        {
            try
            {
                _healthContext.Clinica.Add(clinicaNova);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Clinica> ListarClinicas()
        {
            try
            {
                return _healthContext.Clinica.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
