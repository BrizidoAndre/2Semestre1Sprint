using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext _healthContext;
        public EspecialidadeRepository()
        {
            _healthContext= new HealthContext();
        }

        public void Atualizar(Guid id, Especialidade c)
        {
            Especialidade z = _healthContext.Especialidade.FirstOrDefault(z => z.IdEspecialidade == id)!;
            z.Titulo = c.Titulo;
            _healthContext.Especialidade.Update(z);
            _healthContext.SaveChanges();
        }

        public void Cadastrar(Especialidade especialidadeNova)
        {
            _healthContext.Especialidade.Add(especialidadeNova);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Especialidade especialidadeDeletada = _healthContext.Especialidade.FirstOrDefault(z => z.IdEspecialidade == id)!;
            _healthContext.Especialidade.Remove(especialidadeDeletada);
            _healthContext.SaveChanges();

        }

        public List<Especialidade> Listar()
        {
            return _healthContext.Especialidade.ToList();
        }
    }
}
