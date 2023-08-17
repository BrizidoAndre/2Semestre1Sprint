CREATE FUNCTION EspecialidadeMedica(
	@IdPesquisa INT
)
RETURNS TABLE
AS
RETURN
	SELECT
		tb_Especialidade.IdEspecialidade,
		p1.Nome
	FROM 
			tb_Especialidade
		LEFT JOIN
			tb_Medico ON tb_Medico.IdEspecialidade = tb_Especialidade.IdEspecialidade
		LEFT JOIN
			tb_Usuario as p1 ON p1.IdUsuario = tb_Medico.IdUsuario
	WHERE
	tb_Especialidade.IdEspecialidade = @IdPesquisa
