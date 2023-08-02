--ATIVIDADE DA AULA 6 - DML
USE Exercicio_1_1

--Comando para inserir dados nas tabelas
INSERT INTO Pessoa(Nome,CNH)
VALUES
	('Andr�','1234567890'),
	('Augusto','8192034576'),
	('Zacarias','0987654321'),
	('Hernandes','0192837465'),
	('SemMailNemTel','0151837123')

INSERT INTO Email(IdPessoa,Email)
VALUES 
	(1,'andretaubate2@gmail.com'),
	(2,'AugustoJulho@gmail.com'),
	(3,'Zacarizaz@gmail.com'),
	(4,'HernandeMaunel@gmail.com'),
	(4,'ManuelHernandez@gmail.com')

INSERT INTO Telefone(IdPessoa,Numero)
VALUES 
	(1,'11912347291'),
	(2,'11531342293'),
	(3,'11918867293'),
	(4,'11971245093'),
	(2,'11918265236')

--Comando para visualizar as tabelas criadas

--PARA VISUALIZAR AS TABELAS SEPARADAS
SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone

--JEITO ERRADO DE VISUALIZAR AS TABELAS;;;;NADA DID�TICO;;;;
SELECT * FROM 
	Pessoa,
	Email,
	Telefone

--MELHOR JEITO DE VISUALIZAR OS DADOS EM UMA �NICA TABELA 
-- POSS�VEL PROBLEMA, O VALOR S� APARECE SE POSSUIR TODOS OS CASOS CORRESPONDENTES.    Caso algu�m apare�a sem n�mero ou sem email, ele n�o aparece na tabela
SELECT 
	Pessoa.Nome,
	Pessoa.CNH,
	Email.Email AS Endere�o,
	Telefone.Numero AS Telefone
FROM 
	Pessoa,
	Email, 
	Telefone
WHERE 
	Pessoa.IdPessoa = Email.IdPessoa 
AND Pessoa.IdPessoa = Telefone.IdPessoa

ORDER BY Pessoa.Nome DESC

--MELHOR JEITO DE MOSTRAR TODOS OS VALORES EM UMA �NICA TABELA