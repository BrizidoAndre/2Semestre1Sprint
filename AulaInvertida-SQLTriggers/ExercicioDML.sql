USE ExercicioAulaReversa

INSERT INTO Cliente(Nome,Senha, Email)
VALUES 
	('André', 'password', 'andre@gmail.com'),
	('Pedro', 'senhão', 'pedro@yahoo.com'),
	('Maria', 'senhita', 'email@bol.com')

UPDATE Cliente
SET
	Senha = 'Senhorita'
WHERE IdCliente = 3

SELECT * FROM Cliente
SELECT * FROM ClienteBackUp