USE HealthClinic;

INSERT INTO tb_Perfil(TipoDePerfil)
VALUES
	('Admin'),
	('M�dico'),
	('Paciente')

INSERT INTO tb_Usuario(IdPerfil,Nome,Email,CPF,Senha)
VALUES
	(1,'Gabriela Ramos Mariano Rosa', 'gabi.ramos1309@gmail.com','34587695620','Chiuaua123'),
	(2,'Jo�o Vitor Oliveira Santos','joao.gostosao@gmail.com','12332121320','20533539Jj'),
	(2,'Everton Silva Araujo','evertonaraujosenai@gmail.com','45565478912','caogataoK'),
	(3,'Luis Henrique de jesus Correia','luizinhogameplays@gmail.com','28586061214','TmNg@1984'),
	(3,'Guilherme Sousa Oliveira','guilhermedarth045@gmail.com','45839277642','4444'),
	(3,'Andr� Brizido Basilio', 'brizidao@gmail.com','13556798812','humbertinho345')

INSERT INTO tb_PlanoDeSaude(PlanoDeSaude)
VALUES
	('Sulam�rica Sa�de'),
	('Notredame Interm�dica'),
	('Bradesco Sa�de'),
	('Hapvilda'),
	('Amil'),
	('Unimed')

INSERT INTO tb_Especialidade(Especialidade)
VALUES
	('Cl�nica M�dica'),
	('Cardiologia'),
	('Neurologia'),
	('Psiquiatria'),
	('Endocrinologia'),
	('Ortopedia'),
	('Dermatologia'),
	('Oftalmologia')

INSERT INTO tb_Clinica(RazaoSocial,CNPJ,Endereco,HorarioAbertura,HorarioEncerramento)
VALUES ('Health+','12345678901234','Rua das Brom�nias 71','08:00:00','20:00:00')

INSERT INTO tb_Prontuario(Historico)
VALUES 
	('Nunca passou por uma cl�nica hospitalar antes. Uma an�lise geral � altamente recomendada, poss�veis diverg�ncias ainda n�o registradas'),
	('Foi encaminhado para um especialista card�aco. Problemas que ainda podem surgir nas vias card�acas.')

--aqui estou inserindo a usuario Gabriela como um administrados geral. Assim ela fica classificada como administradora
INSERT INTO tb_administrador(IdUsuario)
VALUES	(1)

INSERT INTO tb_Medico(IdUsuario,IdEspecialidade,IdClinica,CRM,Idade,Salario)
VALUES
	(2,4,1,'123456SP',46,18000),
	(3,7,1,'654321SP',18,14000)

--Aqui estou inserindo os dados do paciente, lembrando que o sexo � um valor bit, sendo 0 feminino e 1 masculino
INSERT INTO tb_Paciente(IdUsuario,IdPlanoDeSaude,DataDeNascimento,Sexo)
VALUES
	(4,3,'1999-08-14',1),
	(5,2,'2002-04-26',1),
	(6,1,'2023-10-09',1)

--Aqui estou inserindo o agendamento, guardando dados envolvendo apenas o hor�rio
INSERT INTO tb_Agendamento(IdAdmin,IdClinica,HorarioDaConsulta)
VALUES
	(1,1,'2023-08-17T14:30:00'),
	(1,1,'2023-08-17T19:00:00')


INSERT INTO tb_Consulta(IdAgendamento,IdMedico,IdPaciente,IdProntuario,Descricao)
VALUES 
	(1,2,3,1,'Consulta Geral'),--Aqui o agendamento � as 14 horas, com o m�dico Everton, Paciente Andr� com prontu�rio que nunca foi a um m�dico
	(2,1,2,2,'Retorno de cirurgia card�aca') --J� aqui o agendamento � as 19 horas com o m�dico Jo�o com prontu�rio de cirurgia card�aca

INSERT INTO tb_Feedback(IdConsulta,IdPaciente,Comentario)
VALUES
	(2,2,'Muito bom o profissional, bastante educado e cooperativo')

INSERT INTO tb_Feedback(IdConsulta,IdPaciente,Comentario)
VALUES
	(1,3,'Uma bosta, muito merda')