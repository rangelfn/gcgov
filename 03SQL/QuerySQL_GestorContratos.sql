--------------------------
--Criando o banco de dados
--------------------------
CREATE DATABASE GestorContratos

-----------------------------
--Selecionando o banco criado
-----------------------------
USE GestorContratos

--------------------------------------
-- Criação da tabela Unidades Gestoras
--------------------------------------
CREATE TABLE UnidadesGestoras (
  UgCodigoID INT PRIMARY KEY,
  UgNome VARCHAR(255) NOT NULL,
  UgCnpj VARCHAR(255) NOT NULL,
  UgContato VARCHAR(255) NOT NULL
);

------------------------------------
  -- Criação da tabela Departamentos
  ----------------------------------
CREATE TABLE UgDepartamentos (
  UgDpID INT PRIMARY KEY IDENTITY,
  UgDpNome VARCHAR(255) NOT NULL,
  UgCodigoID INT,
  FOREIGN KEY (UgCodigoID) REFERENCES UnidadesGestoras (UgCodigoID) ON DELETE CASCADE
);

-----------------------------
-- Criação da tabela Usuarios
-----------------------------
CREATE TABLE Usuarios (
  UsuarioID INT PRIMARY KEY IDENTITY,
  Nome VARCHAR(255) NOT NULL,
  LoginCPF VARCHAR(255) NOT NULL,
  Email VARCHAR(255) NOT NULL,
  Senha VARCHAR(255) NOT NULL
);

-------------------------------
-- Criação da tabela UgUsuarios
--------------------------------
CREATE TABLE UgUsuarios (
  UgUsuariosID INT PRIMARY KEY IDENTITY,
  UsuarioID INT,
  FOREIGN KEY (UsuarioID) REFERENCES Usuarios (UsuarioID) ON DELETE CASCADE, 
  UgCodigoID INT,
  FOREIGN KEY (UgCodigoID) REFERENCES UnidadesGestoras (UgCodigoID) ON DELETE CASCADE, 
);

------------------------
-- Criação da Modalidade
------------------------
CREATE TABLE ModLicitacao (
  ModLicitacaoID INT PRIMARY KEY IDENTITY,
  ModNome VARCHAR(255) NOT NULL
);

------------------------------
-- Criação da tabela Contratos
------------------------------
CREATE TABLE Contratos (
  ContratoID INT PRIMARY KEY IDENTITY,
  Extrato VARCHAR(255) NOT NULL,
  Contratante VARCHAR(255) NOT NULL,
  Contratada VARCHAR(255) NOT NULL,
  Objeto VARCHAR(4000) NOT NULL,
  Vigencia INT NOT NULL,
  DataInicio DATE NOT NULL,
  ProcessoSei VARCHAR(255) NOT NULL,
  LinkPublico VARCHAR(255) NOT NULL,
  DataAssinatura DATE NOT NULL,
  ProtocoloDiof VARCHAR(255) NOT NULL,
  ModLicitacaoID INT,
  FOREIGN KEY (ModLicitacaoID) REFERENCES ModLicitacao (ModLicitacaoID),
  Valor DECIMAL(10, 2),
  UgCodigoID INT,
  FOREIGN KEY (UgCodigoID) REFERENCES UnidadesGestoras (UgCodigoID),
  UgDpID INT,
  FOREIGN KEY (UgDpID) REFERENCES UgDepartamentos (UgDpID)
);

----------------------------
-- Criação da tabela Editais
----------------------------
CREATE TABLE Editais (
  EdtID INT PRIMARY KEY IDENTITY,
  EdtNum VARCHAR(255) NOT NULL,
  EdtTipo VARCHAR(255) NOT NULL,
  EdtLink VARCHAR(255) NOT NULL,
  EdtData DATE NOT NULL,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE
);

-----------------------------
-- Criação da tabela Aditivos
-----------------------------
CREATE TABLE Aditivos (
  AdtID INT PRIMARY KEY IDENTITY,
  AdtNum VARCHAR(255) NOT NULL,
  Descricao VARCHAR(255) NOT NULL,
  AdtData DATE,
  Valor DECIMAL(10, 2) NOT NULL,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE
);

-----------------------------------
-- Criação da tabela Apostilamentos
-----------------------------------
CREATE TABLE Apostilamentos (
  AptID INT PRIMARY KEY IDENTITY,
  AptNum VARCHAR(255) NOT NULL,
  AptDesc VARCHAR(255) NOT NULL,
  AptData DATE,
  Valor DECIMAL(10, 2) NOT NULL,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE
);

-----------------------------------------------------------------------------
-- Criação da tabela Despesa com restrição CHECK utilizando expressão regular
-----------------------------------------------------------------------------
CREATE TABLE DotacaoOrcamentarias (
  NaturezaDespesa INT PRIMARY KEY,
  FonteRecurso INT,
  ProgramaTrabalho INT,
);

----------------------------------
-- Criação da tabela PagamentoModalidade
----------------------------------
CREATE TABLE PgtosModalidade (
  PgtoModID INT PRIMARY KEY IDENTITY,
  PgtoModNome VARCHAR(255) NOT NULL
);

----------------------------------
-- Criação da tabela PagamentoTipo
----------------------------------
CREATE TABLE PgtosTipos (
  PgtoTipoID INT PRIMARY KEY IDENTITY,
  NotaEmpenho VARCHAR(255) NOT NULL,
  DataCadastro DATE NOT NULL,
  PgtoModID INT,
  FOREIGN KEY (PgtoModID) REFERENCES PgtosModalidade (PgtoModID) ON DELETE CASCADE,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE,
  NaturezaDespesa INT,
  FOREIGN KEY (NaturezaDespesa) REFERENCES DotacaoOrcamentarias (NaturezaDespesa) ON DELETE CASCADE 
);

-------------------------------
-- Criação da tabela Pagamentos
-------------------------------
CREATE TABLE Pagamentos (
  PgtoID INT PRIMARY KEY IDENTITY,
  NotaLancamento VARCHAR(255) NOT NULL,
  PreparacaoPagamento VARCHAR(255) NOT NULL,
  OrdemBancaria VARCHAR(255) NOT NULL,
  Valor DECIMAL(10, 2) NOT NULL,
  DataPagamento DATE NOT NULL,
  Parcela VARCHAR(10) NOT NULL,
  PgtoTipoID INT,
  FOREIGN KEY (PgtoTipoID) REFERENCES PgtosTipos (PgtoTipoID) ON DELETE CASCADE 
);

---------------------------------------------------------------
-- Criação da tabela Portaria com clausula CHECK entre as datas
---------------------------------------------------------------
CREATE TABLE Portarias (
  PortariaID INT PRIMARY KEY IDENTITY,
  PortariaNumero VARCHAR(255) NOT NULL,
  ProtocoloDiof VARCHAR(255) NOT NULL,
  DataPublicacao DATE,
  DataInicio DATE,
  CHECK (DataPublicacao <= DataInicio),
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE
);

-----------------------------------------------------------
-- Criação da tabela Pessoa com clausula CHECK no campo CPF
-----------------------------------------------------------
CREATE TABLE Servidores (
  Matricula  INT PRIMARY KEY,
  Nome VARCHAR(255) NOT NULL,
  CPF VARCHAR(11) NOT NULL CHECK (LEN(CPF) = 11),
  UgCodigoID INT,
  FOREIGN KEY (UgCodigoID) REFERENCES UnidadesGestoras (UgCodigoID),
  UgDpID INT,
  FOREIGN KEY (UgDpID) REFERENCES UgDepartamentos (UgDpID) ON DELETE CASCADE,
);


-----------------------------------
-- Criação da tabela PortariaPessoa
-----------------------------------
CREATE TABLE PortariasServidores (
  PortariasPessoasID INT PRIMARY KEY IDENTITY,
  Funcao VARCHAR(255) NOT NULL,
  Resolucao VARCHAR(255) NOT NULL,
  PortariaID INT,
  FOREIGN KEY (PortariaID) REFERENCES Portarias (PortariaID) ON DELETE CASCADE,
  Matricula INT,
  FOREIGN KEY (Matricula) REFERENCES Servidores (Matricula) ON DELETE CASCADE
);

------------------------------
-- Criação da tabela Auditoria
------------------------------
CREATE TABLE Auditorias (
  AuditoriaID INT PRIMARY KEY IDENTITY,
  Tabela VARCHAR(50),
  Acao VARCHAR(10),
  Usuario VARCHAR(70),
  DataHora DATE,
  Chave VARCHAR (255),
  Antes VARCHAR (4000),
  Depois VARCHAR (4000)
);

--------------------------------------
-- Exportando e Importnado um Diagrama
---------------------------------------
-- Exportar
!!bcp GestorContratos.dbo.sysdiagrams out c:\tmp\DiagramaGestorContratos.txt -c -T -S .

-- Importar
!!bcp GestorContratos.dbo.sysdiagrams in c:\tmp\DiagramaGestorContratos.txt -c -T -S .