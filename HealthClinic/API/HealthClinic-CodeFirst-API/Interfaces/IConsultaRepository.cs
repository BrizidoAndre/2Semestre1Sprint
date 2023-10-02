using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IConsultaRepository
    {
        void Cadastrar(Consulta consultaNova);

        List<Consulta> ListarDeMedico(Guid idMedico);
        List<Consulta> ListarDePaciente(Guid idPaciente);

        void Deletar(Guid id);
        void Atualizar(Guid id, Consulta consulta);
    }
}
