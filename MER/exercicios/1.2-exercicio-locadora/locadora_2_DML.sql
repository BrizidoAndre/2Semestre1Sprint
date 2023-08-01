--Início do exercício 6 - DML

--Selecionando a tabela desejada
USE Exercicio_1_2;


--Inserindo Valores nas tabelas
INSERT INTO Cliente(Nome,CPF)
VALUES ('André Basilio','51910007811')

INSERT INTO Empresa(Nome,CNPJ)
VALUES ('Alugueis ltda', '213581239')

INSERT INTO Modelo(Nome)
VALUES ('Ka')

INSERT INTO Marca(Nome)
VALUES ('FORD')

INSERT INTO Veiculo(IdMarca, IdModelo, IdEmpresa, Placa)
VALUES (1,1,1,'hud3145')

INSERT INTO Aluguel(IdCliente, IdVeiculo, Datadecadastro, Dataderetirada)
VALUES (1,1,'2023-08-01', '2023-10-30')


--Visualizando as tabelas
SELECT * FROM Cliente
SELECT * FROM Empresa
SELECT * FROM Modelo
SELECT * FROM Marca
SELECT * FROM Veiculo
SELECT * FROM Aluguel