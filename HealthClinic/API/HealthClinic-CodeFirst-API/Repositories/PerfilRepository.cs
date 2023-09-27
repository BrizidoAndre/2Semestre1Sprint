using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly HealthContext _healthContext;
        public PerfilRepository()
        {
            _healthContext = new HealthContext();
        }

        public void Atualizar(Guid id, Perfil perfilAtualizado)
        {
            try
            {
                Perfil perfilAntigo = _healthContext.Perfil.FirstOrDefault(z => z.IdPerfil == id)!;

                perfilAntigo.TipoDePerfil = perfilAtualizado.TipoDePerfil;

                _healthContext.Perfil.Update(perfilAntigo);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Perfil perfilNovo)
        {
            try
            {
                _healthContext.Perfil.Add(perfilNovo);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Perfil perfilDeletado = _healthContext.Perfil.FirstOrDefault(z => z.IdPerfil == id)!;
                _healthContext.Perfil.Remove(perfilDeletado);
                _healthContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Perfil> Listar()
        {
            return _healthContext.Perfil.ToList();
        }
    }
}
