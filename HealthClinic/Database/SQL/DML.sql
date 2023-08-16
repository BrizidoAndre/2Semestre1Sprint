USE HealthClinic;

INSERT INTO tb_Perfil(TipoDePerfil)
VALUES
	('Admin'),
	('Médico'),
	('Paciente')

INSERT INTO tb_Usuario(IdPerfil,Nome,Email,CPF,Senha)
VALUES
	(1,'Gabriela Ramos Mariano Rosa', 'gabi.ramos1309@gmail.com','34587695620','Chiuaua123'),
	(2,'João Vitor Oliveira Santos','joao.gostosao@gmail.com','12332121320','20533539Jj'),
	(2,'Everton Silva Araujo','evertonaraujosenai@gmail.com','45565478912','caogataoK'),
	(3,'Luis Henrique de jesus Correia','luizinhogameplays@gmail.com','28586061214','TmNg@1984'),
	(3,'Guilherme Sousa Oliveira','guilhermedarth045@gmail.com','45839277642','4444'),
	(3,'André Brizido Basilio', 'brizidao@gmail.com','13556798812','humbertinho345')

INSERT INTO tb_PlanoDeSaude(PlanoDeSaude)
VALUES
	('Sulamérica Saúde'),
	('Notredame Intermédica'),
	('Bradesco Saúde'),
	('Hapvilda'),
	('Amil'),
	('Unimed')

INSERT INTO tb_Especialidade(Especialidade)
VALUES
	('Clínica Médica'),
	('Cardiologia'),
	('Neurologia'),
	('Psiquiatria'),
	('Endocrinologia'),
	('Ortopedia'),
	('Dermatologia'),
	('Oftalmologia')

INSERT INTO tb_Clinica(RazaoSocial,CNPJ,Endereco,HorarioAbertura,HorarioEncerramento)
VALUES ('Health+','12345678901234','Rua das Bromênias 71','08:00:00','20:00:00')

INSERT INTO tb_Prontuario(Historico)
VALUES 
	('Nunca passou por uma clínica hospitalar antes. Uma análise geral é altamente recomendada, possíveis divergências ainda não registradas'),
	('Foi encaminhado para um especialista cardíaco. Problemas que ainda podem surgir nas vias cardíacas.')

--aqui estou inserindo a usuario Gabriela como um administrados geral. Assim ela fica classificada como administradora
INSERT INTO tb_administrador(IdUsuario)
VALUES	(1)

INSERT INTO tb_Medico(IdUsuario,IdEspecialidade,IdClinica,CRM,Idade,Salario)
VALUES
	(2,4,1,'123456SP',46,18000),
	(3,7,1,'654321SP',18,14000)

--Aqui estou inserindo os dados do paciente, lembrando que o sexo é um valor bit, sendo 0 feminino e 1 masculino
INSERT INTO tb_Paciente(IdUsuario,IdPlanoDeSaude,DataDeNascimento,Sexo)
VALUES
	(4,3,'1999-08-14',1),
	(5,2,'2002-04-26',1),
	(6,1,'2023-10-09',1)

--Aqui estou inserindo o agendamento, guardando dados envolvendo apenas o horário
INSERT INTO tb_Agendamento(IdAdmin,IdClinica,HorarioDaConsulta)
VALUES
	(1,1,'2023-08-17T14:30:00'),
	(1,1,'2023-08-17T19:00:00')


INSERT INTO tb_Consulta(IdAgendamento,IdMedico,IdPaciente,IdProntuario,Descricao)
VALUES 
	(1,2,3,1,'Consulta Geral'),--Aqui o agendamento é as 14 horas, com o médico Everton, Paciente André com prontuário que nunca foi a um médico
	(2,1,2,2,'Retorno de cirurgia cardíaca') --Já aqui o agendamento é as 19 horas com o médico João com prontuário de cirurgia cardíaca

INSERT INTO tb_Feedback(IdConsulta,IdPaciente,Comentario)
VALUES
	(2,2,'Muito bom o profissional, bastante educado e cooperativo')

INSERT INTO tb_Feedback(IdConsulta,IdPaciente,Comentario)
VALUES
	(1,3,'Uma bosta, muito merda')