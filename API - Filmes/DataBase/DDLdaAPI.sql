CREATE DATABASE Filmes
GO
USE Filmes

CREATE TABLE Genero(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(80)
	)

CREATE TABLE Filme(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(80)
	)

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(256),
	Senha VARCHAR(100),
	Permissao bit 
	)


INSERT INTO Usuario(Email,Senha,Permissao)
VALUES
	('Admin@admin.com','SenhaForte',1),
	('Usuario@user.com','SenhaPadrão',0)

SELECT * FROM Usuario