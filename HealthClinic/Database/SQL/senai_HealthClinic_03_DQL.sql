USE HealthClinic

--Todas as tabelas separadamente
	select * from tb_administrador
	select * from tb_Agendamento
	select * from tb_Clinica
	select * from tb_Consulta
	select * from tb_Especialidade
	select * from tb_Feedback
	select * from tb_Medico
	select * from tb_Paciente
	select * from tb_Perfil
	select * from tb_PlanoDeSaude
	select * from tb_Prontuario
	select * from tb_Usuario

SELECT
	tb_Consulta.IdConsulta, --FEITO
	tb_Agendamento.HorarioDaConsulta, --feito
	tb_Clinica.RazaoSocial, --FEITO
	p1.Nome,
	P2.Nome,
	tb_Especialidade.Especialidade, --FEITO
	tb_Medico.CRM, --FEITO
	tb_Prontuario.Historico, --FEITO
	tb_Feedback.Comentario --FEITO
FROM
	tb_Consulta
LEFT JOIN
	tb_Agendamento ON tb_Consulta.IdAgendamento = tb_Agendamento.IdAgendamento
LEFT JOIN
	tb_Clinica ON tb_Clinica.IdClinica = tb_Agendamento.IdClinica
LEFT JOIN
	tb_Medico ON tb_Medico.IdMedico = tb_Consulta.IdMedico
LEFT JOIN
	tb_Especialidade ON tb_Especialidade.IdEspecialidade = tb_Medico.IdEspecialidade
LEFT JOIN
	tb_Prontuario ON tb_Prontuario.IdProntuario = tb_Consulta.IdProntuario
LEFT JOIN
	tb_Feedback ON tb_Feedback.IdConsulta = tb_Consulta.IdConsulta
LEFT JOIN
	tb_Paciente ON tb_Consulta.IdPaciente = tb_Paciente.IdPaciente
LEFT JOIN
	tb_Usuario AS p1 ON p1.IdUsuario = tb_Medico.IdUsuario 
LEFT JOIN
	tb_Usuario AS P2 ON P2.IdUsuario = tb_Paciente.IdUsuario


SELECT
	tb_Usuario.Nome,
	tb_Medico.IdMedico,
	tb_Consulta.Descricao
FROM
	tb_Consulta
LEFT JOIN
	tb_Medico ON tb_Medico.IdMedico = tb_Consulta.IdMedico
LEFT JOIN
	tb_Usuario ON tb_Usuario.IdUsuario = tb_Medico.IdUsuario

SELECT *
FROM
EspecialidadeMedica(5)