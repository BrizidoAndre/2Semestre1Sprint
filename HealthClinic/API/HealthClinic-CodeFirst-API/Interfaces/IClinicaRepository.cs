using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinicaNova);

        List<Clinica> ListarClinicas();

        void Atualizar(Guid id , Clinica clinica);
    }
}
