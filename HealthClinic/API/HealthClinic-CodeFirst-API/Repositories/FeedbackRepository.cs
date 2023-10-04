using HealthClinic_CodeFirst_API.Context;
using HealthClinic_CodeFirst_API.Domains;
using HealthClinic_CodeFirst_API.Interfaces;

namespace HealthClinic_CodeFirst_API.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly HealthContext _healthContext;
        public FeedbackRepository()
        {
            _healthContext = new HealthContext();
        }
        public void Atualizar(Guid id, Feedback feedbackAlterado)
        {
            Feedback f = _healthContext.Feedback.FirstOrDefault(z => z.IdFeedback == id)!;
            if (f != null)
            {
                f.IdPaciente = feedbackAlterado.IdPaciente;
                f.IdConsulta = feedbackAlterado.IdConsulta;
                f.Comentario = feedbackAlterado.Comentario;

                _healthContext.Feedback.Update(f);
                _healthContext.SaveChanges();
            }
        }

        public void Cadastrar(Feedback feedbackNovo)
        {
            _healthContext.Feedback.Add(feedbackNovo);
            _healthContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Feedback feedbackDeletado = _healthContext.Feedback.FirstOrDefault(z => z.IdFeedback == id)!;
            if (feedbackDeletado != null)
            {
                _healthContext.Feedback.Remove(feedbackDeletado);
                _healthContext.SaveChanges();

            }
        }

        public List<Feedback> ListarDeUsuario(Guid id)
        {
            //return _healthContext.Feedback.Select(z => new Feedback
            //{
            //    Comentario = z.Comentario,
            //    IdConsulta = z.IdConsulta,
            //    Consulta = new Consulta
            //    {
            //        IdClinica = z.Consulta.IdClinica,
            //        Clinica = new Clinica
            //        {
            //            RazaoSocial = z.Consulta!.Clinica!.RazaoSocial,
            //        },
            //        HorarioDaConsulta = z.Consulta.HorarioDaConsulta,
            //        Descricao = z.Consulta.Descricao,
            //        IdMedico = z.Consulta.IdMedico,
            //        Medico = new Medico
            //        {
            //            Nome = z.Consulta.Medico!.Nome,
            //            IdEspecialidade= z.Consulta.Medico.IdEspecialidade,
            //            Especialidade = new Especialidade
            //            {
            //                Titulo = z.Consulta.Medico.Especialidade!.Titulo
            //            }
            //        },
            //        IdPaciente= z.Consulta.IdPaciente,
            //        Paciente = new Paciente
            //        {
            //            Name = z.Consulta.Paciente!.Name,
            //            Sexo = z.Consulta.Paciente.Sexo
            //        }
            //    }
            //}).Where(z => z.IdPaciente == id).ToList();

            return _healthContext.Feedback.Select(z => new Feedback
            {
                Comentario = z.Comentario,
                IdPaciente = z.IdPaciente,
                IdConsulta = z.IdConsulta,
                Paciente = new Paciente
                {
                    Name = z.Paciente.Name,
                    IdPlanoDeSaude = z.Paciente.IdPlanoDeSaude,
                    PlanoDeSaude = new PlanoDeSaude
                    {
                        Titulo = z.Paciente.PlanoDeSaude.Titulo
                    }
                },
                Consulta = z.Consulta,

            }).Where(z => z.IdPaciente == id).ToList();
        }
    }
}
