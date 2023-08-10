--DML Data Manipulation Language
USE [Event+Manha]

--inserir dados nas tabelas

INSERT INTO TipoDeUsuario(TituloTipoUsuario)
VALUES 
	('Administrador'),
	('Comum')

INSERT INTO TipoDeEvento(TituloTipoEvento)
VALUES 
	('SQL Server')

INSERT INTO Instituicao(CNPJ,Endereco,NomeFantasia)
VALUES
	('12345678901234','Rua Niter�i 180', 'DevSchool')

INSERT INTO Usuario(IdTipoDeUsuario,Nome,Email,Senha)
VALUES
	(1, 'Andr�','abrizidobasilio@gmail.com', 'Passwords')

INSERT INTO Evento(IdTipoDeEvento,IdInstituicao,NomeEvento,Descricao,DataEvento,TimeEvento)
VALUES
	(1,1,'Introdu��o ao Banco de Dados SQL Server','Uma colet�nia de apresenta��es e conceitos b�sicos sobre a ferramenta e o profissional de SQL server','2023-08-11','10:30:00')

INSERT INTO PresencaEvento(IdEvento,IdUsuario,Situacao)
VALUES 
	(1,1,1)

INSERT INTO Comentario(IdUsuario,IdEvento,Descricao,Exibe)
VALUES
	(1,1,'Excelente evento, Bons professores',1)

