USE Exercicio_1_3

INSERT INTO TipoDePet(Nome)
VALUES 
	('Passaro'),
	('Cão'),
	('Gato')

INSERT INTO Raca(IdTipodePet,Nome)
VALUES 
	(2,'Pincher'),
	(2,'Buldogue')

INSERT INTO Dono(Nome, Endereco)
VALUES 
	('João Barros','Rua Meideiros 135'),
	('Maria das Dores','Rua Jacuzzi 98')


SELECT * FROM TipoDePet ORDER BY Nome
SELECT * FROM Raca
SELECT * FROM Dono
SELECT * FROM Pet
SELECT * FROM Veterinario
SELECT * FROM Clinica
SELECT * FROM Atendimento
