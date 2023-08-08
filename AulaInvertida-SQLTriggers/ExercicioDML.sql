USE ExercicioAulaReversa

INSERT INTO Cliente(Nome,Senha, Email)
VALUES 
	('André', 'password', 'andre@gmail.com'),
	('Pedro', 'senhão', 'pedro@yahoo.com'),
	('Maria', 'senhita', 'email@bol.com')

UPDATE Cliente
SET
	Senha = 'Senhorita'
WHERE IdCliente = 3

SELECT * FROM Cliente
SELECT * FROM ClienteBackUp

SELECT 
     sysobjects.name AS trigger_name 
    ,USER_NAME(sysobjects.uid) AS trigger_owner 
    ,s.name AS table_schema 
    ,OBJECT_NAME(parent_obj) AS table_name 
    ,OBJECTPROPERTY( id, 'ExecIsUpdateTrigger') AS isupdate 
    ,OBJECTPROPERTY( id, 'ExecIsDeleteTrigger') AS isdelete 
    ,OBJECTPROPERTY( id, 'ExecIsInsertTrigger') AS isinsert 
    ,OBJECTPROPERTY( id, 'ExecIsAfterTrigger') AS isafter 
    ,OBJECTPROPERTY( id, 'ExecIsInsteadOfTrigger') AS isinsteadof 
    ,OBJECTPROPERTY(id, 'ExecIsTriggerDisabled') AS [disabled] 
FROM sysobjects 
INNER JOIN sys.tables t 
    ON sysobjects.parent_obj = t.object_id     
INNER JOIN sys.schemas s 
    ON t.schema_id = s.schema_id 
WHERE sysobjects.type = 'TR'