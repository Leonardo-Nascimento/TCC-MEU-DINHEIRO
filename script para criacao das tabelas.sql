/************************************************************
 * Code formatted by SoftTree SQL Assistant © v7.5.502
 * Time: 01/11/2018 08:55:30
 ************************************************************/
USE BDCADASTRO


CREATE TABLE Cliente
(
	idCliente     INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	nome          VARCHAR(200) NOT NULL,
	email         VARCHAR(200) NOT NULL,
	senha         VARCHAR(200) NOT NULL
)







CREATE TABLE Cliente_Movimentacao (
  idCliente INT NOT NULL,
  idTipoDespesa INT ,
  idDespesa INT ,
  idTipoReceita INT ,
  idReceita INT 
  
  
  CONSTRAINT fk_Cliente
  FOREIGN KEY (idCliente)
  REFERENCES Cliente(idCliente),
  
  CONSTRAINT fk_idTipoDespesa
  FOREIGN KEY (idTipoDespesa)
  REFERENCES TipoDespesa(idTipoDespesa),
  
  CONSTRAINT fk_idDespesas
  FOREIGN KEY (idDespesa)
  REFERENCES Despesas(idDespesa),
    
  CONSTRAINT fk_IdTipoReceita
  FOREIGN KEY(idTipoReceita)
  REFERENCES TipoReceita(idTipoReceita),
  
  CONSTRAINT fk_idReceita
  FOREIGN KEY (idReceita)
  REFERENCES Receitas(idReceita),
  
);

CREATE TABLE Conta (
  idConta INT IDENTITY(1, 1) NOT NULL,
  idCliente INT NOT NULL,
  NomeConta VARCHAR (50),
  TipoConta VARCHAR (50),
  PRIMARY KEY(idConta),
  
  CONSTRAINT fk_idCliente
  FOREIGN KEY (idCliente)
  REFERENCES Cliente(idCliente)
);



CREATE TABLE Orçamentos (
  idOrçamento INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  Tipo_Orçamento_idTipoOrçamento INTEGER UNSIGNED NOT NULL,
  Cliente_idIdCliente INTEGER UNSIGNED NOT NULL,
  DsOrçamento VARCHAR (50),
  Valor FLOAT NULL,
  PRIMARY KEY(idOrçamento, Tipo_Orçamento_idTipoOrçamento, Cliente_idIdCliente),
  INDEX Orçamentos_FKIndex1(Tipo_Orçamento_idTipoOrçamento),
  INDEX Orçamentos_FKIndex2(Cliente_idIdCliente)
);



CREATE TABLE Despesas (
  idDespesa INT IDENTITY(1, 1) NOT NULL,
  TipoDespesa INT,
  DATA DATE,
  DsDespesa VARCHAR (50),
  valorDespesa DECIMAL ,
  PRIMARY KEY(idDespesa),
  
  CONSTRAINT fk_TipoDespesa_IdTipoDespesa
  FOREIGN KEY (TipoDespesa)
  REFERENCES TipoDespesa(idTipoDespesa)
  
);



CREATE TABLE Receitas (
  idReceita INT IDENTITY(1, 1) NOT NULL,
  TipoReceita INT,
  DATA DATE,  
  DsReceita VARCHAR(50) ,
  ValorReceita DECIMAL,  
  PRIMARY KEY(idReceita),
  
  CONSTRAINT fk_TipoReceita_IdTipoReceita
  FOREIGN KEY(TipoReceita)
  REFERENCES TipoReceita(IdTipoReceita)
  
);



CREATE TABLE Tipo_Orçamento (
  idTipoOrçamento INT NOT NULL AUTO_INCREMENT,
  Tipo__despesa_idTipoDespesa INTEGER UNSIGNED NOT NULL,
  DsTipoOrçamento VARCHAR NULL,
  PRIMARY KEY(idTipoOrçamento),
  INDEX Tipo_Orçamento_FKIndex1(Tipo__despesa_idTipoDespesa)
);



CREATE TABLE TipoReceita (
  IdTipoReceita INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  tipoReceitaIdCliente INT,
  DsTipoReceita VARCHAR(50), 
);



CREATE TABLE TipoDespesa (
  idTipoDespesa INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  tipoDespesaIdCliente INT ,
  DsTipoDespesa VARCHAR (50),
  
  );



--/*----------INSERINDO TIPOS DE RECEITA------------*/

INSERT INTO TipoReceita VALUES(NULL,'Investimentos')

INSERT INTO TipoReceita VALUES(NULL,'Salário')

INSERT INTO TipoReceita VALUES(NULL,'Reembolso'

INSERT INTO TipoReceita VALUES(NULL,'Estorno')

INSERT INTO TipoReceita VALUES(NULL,'Outras Receitas')



--/*----------INSERINDO RECEITAS------------*/


INSERT INTO Receitas(TipoReceita,ValorReceita,Data,DsReceita)VALUES(2,2400,'07-02-2019','Meu salário')

INSERT INTO Receitas(TipoReceita,ValorReceita,Data,DsReceita)VALUES(5,100,'07-02-2019','Conserto de pc')

INSERT INTO Receitas(TipoReceita,ValorReceita,Data,DsReceita)VALUES(5,100,'07-02-2019','venda da peça da bike')

----------------INSERT TIPO CONTA-----------------

INSERT INTO Conta
(
	-- idConta -- this column value is auto-generated
	idCliente,
	NomeConta,
	TipoConta
)
VALUES
(
	1,
	'Carteira',
	'Pessoal'
)



-