--Selecionando a tabela desejada
USE Exercicio_1_2;

---DQL

--LISTANDO TODOS OS ALUGUEIS E SEUS MODELOS
SELECT 
	Datadecadastro,
	Dataderetirada,
	Cliente.Nome,
	Modelo.Nome

FROM Aluguel

LEFT JOIN Cliente ON Cliente.IdCliente = Aluguel.IdCliente
LEFT JOIN Veiculo ON Veiculo.IdVeiculo = Aluguel.IdVeiculo
LEFT JOIN Modelo ON Modelo.IdModelo = Veiculo.IdModelo

--LISTANDO OS ALUGUEIS DE UM CLIENTE APENAS
SELECT
	Cliente.Nome,
	Aluguel.Datadecadastro,
	Aluguel.Dataderetirada,
	Modelo.Nome

FROM Aluguel

RIGHT JOIN Cliente ON Cliente.IdCliente = Aluguel.IdCliente
LEFT JOIN Veiculo ON Veiculo.IdVeiculo = Aluguel.IdVeiculo
LEFT JOIN Modelo ON Modelo.IdModelo = Veiculo.IdModelo

WHERE Cliente.Nome = 'João Carlos' --Insira o nome do cliente aqui