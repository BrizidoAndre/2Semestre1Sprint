using HealthClinic_CodeFirst_API.Domains;

namespace HealthClinic_CodeFirst_API.Interfaces
{
    public interface IAdministradorRepository
    {
        void Cadastrar(Administrador adminNovo);
    }
}
