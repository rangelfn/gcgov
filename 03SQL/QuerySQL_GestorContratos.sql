--------------------------
--Criando o banco de dados
--------------------------
CREATE DATABASE GCGov

-----------------------------
--Selecionando o banco criado
-----------------------------
USE GCGov

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
CREATE TABLE Modalidade (
  ModId INT PRIMARY KEY IDENTITY,
  ModNome VARCHAR(255) NOT NULL
);

----------------------------------
-- Criação da tabela Complexidade
----------------------------------
CREATE TABLE Complexidade (
  ComplexID INT PRIMARY KEY IDENTITY,
  ComplexNome VARCHAR(255) NOT NULL
);

----------------------------------
-- Criação da tabela Tipo
----------------------------------
CREATE TABLE Tipo (
  TipoID INT PRIMARY KEY IDENTITY,
  TipoNome VARCHAR(255) NOT NULL
);

------------------------------
-- Criação da tabela Contratos
------------------------------
CREATE TABLE Contratos (
  ContratoID INT PRIMARY KEY IDENTITY,
  Extrato VARCHAR(255) UNIQUE NOT NULL,
  Contratante VARCHAR(255) NOT NULL,
  Contratada VARCHAR(255) NOT NULL,
  Objeto VARCHAR(4000) NOT NULL,
  Vigencia INT NOT NULL,
  DataInicio DATE NOT NULL,
  ProcessoSei VARCHAR(255) NOT NULL,
  LinkPublico VARCHAR(255) NOT NULL,
  DataAssinatura DATE NOT NULL,
  ProtocoloDiof VARCHAR(255) NOT NULL,
  Valor DECIMAL(10, 2),
  ComplexID INT,
  FOREIGN KEY (ComplexID) REFERENCES Complexidade (ComplexID),
  TipoID INT,
  FOREIGN KEY (TipoID) REFERENCES Tipo (TipoID),
  ModId INT,
  FOREIGN KEY (ModId) REFERENCES Modalidade (ModId),
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
  EdtNum VARCHAR(255) UNIQUE NOT NULL,
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
  AdtNum VARCHAR(255) UNIQUE NOT NULL,
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
  AptNum VARCHAR(255) UNIQUE NOT NULL,
  AptDesc VARCHAR(255) NOT NULL,
  AptData DATE,
  Valor DECIMAL(10, 2) NOT NULL,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE
);

-----------------------------------------------------------------------------
-- Criação da tabela Despesa com restrição CHECK utilizando expressão regular
-----------------------------------------------------------------------------
CREATE TABLE NaturezaDespesas (
  NatDespId INT PRIMARY KEY,
  FonteRecurso VARCHAR(50),
  ProgramaTrabalho VARCHAR(50),
  ElementoDespesa VARCHAR(50),
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
CREATE TABLE PgtosOrigem (
  PgtosOrigemID INT PRIMARY KEY IDENTITY,
  NotaEmpenho VARCHAR(255) NOT NULL,
  DataCadastro DATE NOT NULL,
  PgtoModID INT,
  FOREIGN KEY (PgtoModID) REFERENCES PgtosModalidade (PgtoModID) ON DELETE CASCADE,
  ContratoID INT,
  FOREIGN KEY (ContratoID) REFERENCES Contratos (ContratoID) ON DELETE CASCADE,
  NatDespId INT,
  FOREIGN KEY (NatDespId) REFERENCES NaturezaDespesas (NatDespId) ON DELETE CASCADE 
);

-------------------------------
-- Criação da tabela Pagamentos
-------------------------------
CREATE TABLE Pagamentos (
  PgtoID INT PRIMARY KEY IDENTITY,
  NotaLancamento VARCHAR(255) UNIQUE NOT NULL,
  PreparacaoPagamento VARCHAR(255) NOT NULL,
  OrdemBancaria VARCHAR(255) NOT NULL,
  Valor DECIMAL(10, 2) NOT NULL,
  DataPagamento DATE NOT NULL,
  Parcela VARCHAR(10) NOT NULL,
  PgtosOrigemID INT,
  FOREIGN KEY (PgtosOrigemID) REFERENCES PgtosOrigem (PgtosOrigemID) ON DELETE CASCADE 
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
  PortariasServidorID INT PRIMARY KEY IDENTITY,
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


-- Exportar
!!bcp GestorContratos.dbo.sysdiagrams out c:\tmp\DiagramaGestorContratos.txt -c -T -S .

-- Importar
!!bcp GestorContratos.dbo.sysdiagrams in c:\tmp\DiagramaGestorContratos.txt -c -T -S .

-----------------------------------------
-- MODIFICAÇÕES DE ESTRUTURA PARA UNIQUE
-----------------------------------------

USE GestorContratos
ALTER TABLE Contratos
ADD CONSTRAINT UC_Extrato UNIQUE (Extrato);

USE GestorContratos
ALTER TABLE Aditivos
ADD CONSTRAINT UC_AdtNum UNIQUE (AdtNum);

ALTER TABLE Editais
ADD CONSTRAINT UC_EdtNum UNIQUE (EdtNum);

ALTER TABLE Apostilamentos
ADD CONSTRAINT UC_AptNum UNIQUE (AptNum);

ALTER TABLE Pagamentos
ADD CONSTRAINT UC_NotaLancamento UNIQUE (NotaLancamento);

ALTER TABLE Contratos
ADD ComplexID INT;

ALTER TABLE Contratos
ADD TipoID INT;

ALTER TABLE Contratos
ADD CONSTRAINT FK_Complexidade_Contratos FOREIGN KEY (ComplexID) REFERENCES Complexidade (ComplexID);

ALTER TABLE Contratos
ADD CONSTRAINT FK_Tipo_Contratos FOREIGN KEY (TipoID) REFERENCES Tipo (TipoID);