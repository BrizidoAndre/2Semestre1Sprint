--Trazer o nome do usuário, Tipo do Usuário, Data do evento, Local do Evento (Instituição)
--Titulo do Evento, Nome do evento, Descrição do evento, Situação do Evento, Comentário do Evento
USE [Event+Manha]

SELECT 

	Usuario.Nome,
	TipoDeUsuario.TituloTipoUsuario AS [Tipo de Acesso],
	Evento.DataEvento AS [Data],
	CONCAT(Instituicao.NomeFantasia, ' - ' , Instituicao.Endereco) AS [Local],
	TipoDeEvento.TituloTipoEvento AS Título, 
	Evento.NomeEvento AS Nome, 
	Evento.Descricao AS Resumo, 
	CASE WHEN PresencaEvento.Situacao = 1 THEN 'Confirmada' ELSE 'Não confirmada' END AS Presença,
	Comentario.Descricao AS Comentário

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