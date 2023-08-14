--Trazer o nome do usu�rio, Tipo do Usu�rio, Data do evento, Local do Evento (Institui��o)
--Titulo do Evento, Nome do evento, Descri��o do evento, Situa��o do Evento, Coment�rio do Evento
USE [Event+Manha]

SELECT 

	Usuario.Nome,
	TipoDeUsuario.TituloTipoUsuario AS [Tipo de Acesso],
	Evento.DataEvento AS [Data],
	CONCAT(Instituicao.NomeFantasia, ' - ' , Instituicao.Endereco) AS [Local],
	TipoDeEvento.TituloTipoEvento AS T�tulo, 
	Evento.NomeEvento AS Nome, 
	Evento.Descricao AS Resumo, 
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmada' ELSE 'N�o confirmada' END AS Presen�a,
	Comentario.Descricao AS Coment�rio

FROM Usuario
	LEFT JOIN TipoDeUsuario 
		ON Usuario.IdTipoDeUsuario = TipoDeUsuario.IdTipoDeUsuario
	LEFT JOIN PresencaEvento
		ON PresencaEvento.IdUsuario = Usuario.IdUsuario
	LEFT JOIN Evento
		ON PresencaEvento.IdEvento = Evento.IdEvento
	LEFT JOIN TipoDeEvento
		ON Evento.IdTipoDeEvento = TipoDeEvento.IdTipoDeEvento
	LEFT JOIN Instituicao
		ON Evento.IdInstituicao = Instituicao.IdInstituicao
	LEFT JOIN Comentario
		ON Comentario.IdUsuario = Usuario.IdUsuario