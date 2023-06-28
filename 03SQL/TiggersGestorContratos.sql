------------------------------------------------
--Ttrigger para bloquear grava��es no DB nos FDS
------------------------------------------------
USE GestorContratos;
GO
CREATE TRIGGER RestricaoFinaisDeSemana
ON Contratos 
FOR INSERT, UPDATE, DELETE
AS
BEGIN
    -- Verifica se o dia atual � s�bado ou domingo
    IF DATEPART(WEEKDAY, GETDATE()) IN (1, 7)
    BEGIN
        -- Cancela a opera��o atual gerando um erro
        RAISERROR ('Altera��es nos finais de semana n�o s�o permitidas.', 16, 1)
        ROLLBACK TRANSACTION
        RETURN
    END
END
-------------------------------------------------
-- Trigger para salvar altera��es para Auditorias
-------------------------------------------------
CREATE TRIGGER AuditarContratos
ON Contratos
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Acao VARCHAR(10)

    -- Verifica o tipo de a��o
    IF EXISTS(SELECT * FROM inserted)
    BEGIN
        IF EXISTS(SELECT * FROM deleted)
            SET @Acao = 'Update' -- A��o de atualiza��o
        ELSE
            SET @Acao = 'Insert' -- A��o de inser��o
    END
    ELSE
        SET @Acao = 'Delete' -- A��o de exclus�o

    -- Insere os registros de auditoria
    INSERT INTO Auditorias (Tabela, Acao, Usuario, DataHora, Chave, Antes, Depois)
    SELECT 'Contratos', @Acao, SUSER_SNAME(), GETDATE(), 
        COALESCE(CONVERT(VARCHAR(100), i.ContratoID), CONVERT(VARCHAR(100), d.ContratoID)), -- Chave prim�ria
        CONVERT(NVARCHAR(MAX), (SELECT * FROM deleted FOR XML AUTO, ELEMENTS)), -- Valores antes da a��o
        CONVERT(NVARCHAR(MAX), (SELECT * FROM inserted FOR XML AUTO, ELEMENTS)) -- Valores depois da a��o
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.ContratoID = d.ContratoID -- Compara registros inseridos e deletados
END

---------------------------------
-- Listar as Triggers existentes
---------------------------------
SELECT name, object_name(parent_id) AS table_name
FROM sys.triggers
WHERE parent_id > 0

-------------------------------------
-- Habilitar e desabilitar as trigger
-------------------------------------
DISABLE TRIGGER AuditarContratos ON Contratos;
ENABLE TRIGGER AuditarContratos ON Contratos;

DISABLE TRIGGER RestricaoFinaisDeSemana ON Contratos;
ENABLE TRIGGER RestricaoFinaisDeSemana ON Contratos;

-------------------------------------
-- Verifica Status das triggers
-------------------------------------
SELECT name, is_disabled
FROM sys.triggers;

