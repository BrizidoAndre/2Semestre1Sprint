USE ExercicioAulaReversa

INSERT INTO Cliente(Nome,Senha, Email)
VALUES 
	('Andr�', 'password', 'andre@gmail.com'),
	('Pedro', 'senh�o', 'pedro@yahoo.com'),
	('Maria', 'senhita', 'email@bol.com')

UPDATE Cliente
SET
	Senha = 'Senhorita'
WHERE IdCliente = 3

SELECT * FROM Cliente
SELECT * FROM ClienteBackUp