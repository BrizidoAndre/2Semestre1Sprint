CREATE TRIGGER PutBackUp
ON Cliente
FOR UPDATE
AS
INSERT INTO ClienteBackUp(IdCliente,Nome,Senha,Email)
SELECT IdCliente, Nome, Senha, Email FROM deleted;