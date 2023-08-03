USE Exercicio_1_4

INSERT INTO Artista(Nome)
VALUES 
	('Seu Jorge'),
	('Titãs'),
	('Elis Regina'),
	('Toby')

INSERT INTO Estilo(Nome)
VALUES 
	('MPB'),
	('Eletrônica'),
	('Pop'),
	('Samba'),
	('Rock')

INSERT INTO Usuario(Nome,Senha,Email,Permissão)
VALUES
	('Ouvinte','passwordOuvinte','ouvemail@gmail.com',0),
	('Ouvinte2','password222Ouvinte','ouve@gmail.com',0),
	('Ouvinte3','pass333Ouvi','3mail@gmail.com',0),
	('Artista','ArtistaSenha','Artista@gmail.com',1),
	('Elis','Reginão','ReginaElias@gmail.com',1)

INSERT INTO Album(IdArtista,Titulo,Localizacao,Tempo,DataLancamento,Ativo)
VALUES
	(3,'Como nossos pais', 'Spotify', '12:00:00', GETDATE(), 1),
	(2,'15 minutos de fama', 'Youtube', '00:15:00', '09-10-2004', 1),
	(4,'Proibidão', 'Youtube', '03:00:00', '24-01-1969', 0)

INSERT INTO AlbumEstilo(IdAlbum,IdEstilo)
VALUES
	(1,1),
	(2,4),
	(3,2),
	(3,3)

INSERT INTO AlbumUsuario(IdUsuario,IdAlbum)
VALUES
	(1,2),
	(1,1),
	(1,3),
	(5,2),
	(4,3)

SELECT * FROM Album
SELECT * FROM Artista
SELECT * FROM Estilo
SELECT * FROM Usuario
SELECT * FROM AlbumEstilo
SELECT * FROM AlbumUsuario