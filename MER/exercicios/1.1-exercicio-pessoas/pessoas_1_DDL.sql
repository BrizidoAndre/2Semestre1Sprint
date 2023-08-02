--ATIVIDADE DA AULA 5 - DDL
--Criando a database
CREATE DATABASE Exercicio_1_1;

--Usando a database criada
USE Exercicio_1_1


--Criando as tabelas do exercício
CREATE TABLE Pessoa(
	IdPessoa INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	CNH VARCHAR(10) NOT NULL
)

CREATE TABLE Email(
	IdEmail INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	Email VARCHAR(256) NOT NULL
)

CREATE TABLE Telefone(
	IdTelefone INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	Numero VARCHAR (30) NOT NULL
)

DROP DATABASE Exercicio_1_1
