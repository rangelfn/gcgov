-------------------------------
-- Seleciona o Banco criado
-------------------------------

USE GestorContratos


-----------------------------------
-- Cria View: Editais por contratos
-----------------------------------

CREATE VIEW ViewEditaisPorContratos
AS
SELECT C.UgCodigo, c.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       E.EdtNum, E.EdtTipo, E.EdtData
FROM Contratos C
INNER JOIN Editais E ON C.ContratoID = E.ContratoID;


---------------------------------
-- Cria: Pagamentos por contratos
---------------------------------

CREATE VIEW vwContratosPagamentos AS
SELECT C.UgCodigo, c.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       pt.NotaEmpenho, pt.DataCadastro,
       p.NotaLancamento, p.PreparacaoPagamento, p.OrdemBancaria, p.Valor AS ValorPagamento,
       p.DataPagamento, p.Parcela
FROM Contratos c
JOIN PgtosTipos pt ON c.ContratoID = pt.ContratoID
JOIN Pagamentos p ON PT.PgtoTipoID = p.PgtoID;

--------------------------------------------------
-- Cria View: Contratos com Detalhes de Pagamentos
--------------------------------------------------
CREATE VIEW ViewContratosPagamentos
AS
SELECT C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       P.NotaLancamento, P.PreparacaoPagamento, P.OrdemBancaria, P.DataPagamento, P.Valor AS ValorPagamento,
       PT.NotaEmpenho, PT.PgtoModalidade
FROM Contratos C
INNER JOIN PgtosTipos PT ON C.ContratoID = PT.ContratoID
INNER JOIN Pagamentos P ON PT.PgtoTipoID = P.PgtoID;


-------------------------------------------------
-- Cria View: Valor Total de Pagamentos por contratos
-------------------------------------------------

CREATE VIEW ViewPagamentosTotalPorContrato
AS
SELECT C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       STRING_AGG(P.NotaLancamento, ', ') AS NotasLancamento, 
       SUM(P.Valor) AS ValorTotalPagamentos
FROM Contratos C
INNER JOIN PgtosTipos PT ON C.ContratoID = PT.ContratoID
INNER JOIN Pagamentos P ON PT.PgtoTipoID = P.PgtoID
GROUP BY C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor;


---------------------------------------------
-- Cria View: Despesas Orçamentaria por contratos
---------------------------------------------
CREATE VIEW DespesasPorContratos
AS
SELECT C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       DO.Programa, DO.Acao, DO.Fonte, DO.Natureza, DO.Elemento
FROM Contratos C
INNER JOIN DotacaoOrcamentarias DO ON C.ContratoID = DO.ContratoID;


---------------------------------
-- Cria View: Portarias por contratos
---------------------------------

CREATE VIEW vwPortariasPorContratos
AS
SELECT C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       P.PortariaNumero, P.ProtocoloDiof, P.DataPublicacao
FROM Contratos C
INNER JOIN Portarias P ON C.ContratoID = P.ContratoID;


---------------------------------
-- Cria View: Pessoas por Contratos
---------------------------------
CREATE VIEW PessoasPorContratos
AS
SELECT C.UgCodigo, C.ProcessoSei, C.Contratada, C.Objeto, C.ModID, C.Valor,
       P.Matricula, P.Nome,
       PP.Funcao, PP.Tipo
FROM Contratos C
INNER JOIN PortariasPessoas PP ON PP.PortariaID = PP.PortariaID
INNER JOIN Pessoas P ON PP.PessoaID = P.PessoaID;