-------------------------------
-- Seleciona o Banco criado
-------------------------------

USE GestorContratos


-----------------------------------
-- Cria View: Editais por contratos
-----------------------------------

CREATE VIEW ViewEditaisPorContratos
AS
SELECT C.UgCodigoID, c.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       E.EdtNum, E.EdtTipo, E.EdtData
FROM Contratos C
INNER JOIN Editais E ON C.ContratoID = E.ContratoID;

--------------------------------------------------
-- Cria View: Contratos com Detalhes de Pagamentos
--------------------------------------------------
CREATE VIEW ViewContratosPagamentos
AS
SELECT C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       P.NotaLancamento, P.PreparacaoPagamento, P.OrdemBancaria, P.DataPagamento, P.Valor AS ValorPagamento,
       PT.NotaEmpenho, PT.PgtoModID
FROM Contratos C
INNER JOIN PgtosTipos PT ON C.ContratoID = PT.ContratoID
INNER JOIN Pagamentos P ON PT.PgtoTipoID = P.PgtoID;


-------------------------------------------------
-- Cria View: Valor Total de Pagamentos por contratos
-------------------------------------------------

CREATE VIEW ViewPagamentosTotalPorContrato
AS
SELECT C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       STRING_AGG(P.NotaLancamento, ', ') AS NotasLancamento, 
       SUM(P.Valor) AS ValorTotalPagamentos
FROM Contratos C
INNER JOIN PgtosTipos PT ON C.ContratoID = PT.ContratoID
INNER JOIN Pagamentos P ON PT.PgtoTipoID = P.PgtoID
GROUP BY C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor;


---------------------------------------------
-- Cria View: Despesas Orçamentaria por contratos
---------------------------------------------
CREATE VIEW ViewDotacaoPorContratos 
AS
SELECT C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       DO.NaturezaDespesa, DO.FonteRecurso, DO.ProgramaTrabalho
FROM Contratos C
INNER JOIN PgtosTipos PT ON C.ContratoID = PT.ContratoID
INNER JOIN DotacaoOrcamentarias DO ON PT.NaturezaDespesa = DO.NaturezaDespesa;




---------------------------------
-- Cria View: Portarias por contratos
---------------------------------

CREATE VIEW ViewPortariasPorContratos
AS
SELECT C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       P.PortariaNumero, P.ProtocoloDiof, P.DataPublicacao
FROM Contratos C
INNER JOIN Portarias P ON C.ContratoID = P.ContratoID;


---------------------------------
-- Cria View: Pessoas por Contratos
---------------------------------
CREATE VIEW ViewServidoresPorContratos
AS
SELECT C.UgCodigoID, C.ProcessoSei, C.Contratada, C.Objeto, C.ModLicitacaoID, C.Valor,
       S.Matricula, S.Nome,
       PS.Funcao, PS.Resolucao
FROM Contratos C
INNER JOIN Portarias P ON C.ContratoID = P.ContratoID
INNER JOIN PortariasServidores PS ON P.PortariaID = PS.PortariaID
INNER JOIN Servidores S ON PS.Matricula = S.Matricula;

