CREATE DATABASE ExercicioAulaReversa

USE ExercicioAulaReversa

CREATE TABLE Cliente(
	IdCliente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(80)  NOT NULL,
	Senha VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL
)

CREATE TABLE ClienteBackUp(
	IdClienteBackUp INT PRIMARY KEY IDENTITY,
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL,
	Nome VARCHAR(80)  NOT NULL,
	Senha VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL
)
