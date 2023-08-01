--ATIVIDADE DA AULA 6 - DML
--Comando para inserir dados nas tabelas
INSERT INTO Pessoa(Nome,CNH)
VALUES('André','1234567890')

INSERT INTO Email(IdPessoa,Email)
VALUES (1,'andretaubate@gmail.com')

INSERT INTO Telefone(IdPessoa,Numero)
VALUES (1,'11912347293')

--Comando para visualizar as tabelas criadas
SELECT * FROM Pessoa
SELECT * FROM Email
SELECT * FROM Telefone