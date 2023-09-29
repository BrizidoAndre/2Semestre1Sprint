using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class PlanoDeSaudeRepository : IPlanoDeSaudeRepository
    {
        private readonly HealthContext _healthContext;
        public PlanoDeSaudeRepository()
        {
            _healthContext= new HealthContext();
        }
        public void Atualizar(Guid id, PlanoDeSaude planoNovo)
        {
            PlanoDeSaude planoBuscado = _healthContext.PlanoDeSaude.FirstOrDefault(z => z.IdPlanoDeSaude == id)!;

            planoBuscado.Titulo = planoNovo.Titulo;

            _healthContext.PlanoDeSaude.Update(planoBuscado);
            _healthContext.SaveChanges();
        }

        public void Cadastrar(PlanoDeSaude planoNovo)
        {
            _healthContext.PlanoDeSaude.Add(planoNovo);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PlanoDeSaude planoDeletado = _healthContext.PlanoDeSaude.FirstOrDefault(z => z.IdPlanoDeSaude == id)!;
            _healthContext.PlanoDeSaude.Remove(planoDeletado);
            _healthContext.SaveChanges();

        }

        public List<PlanoDeSaude> Listar()
        {
            return _healthContext.PlanoDeSaude.ToList();
        }
    }
}
