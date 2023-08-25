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