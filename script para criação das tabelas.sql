/************************************************************
 * Code formatted by SoftTree SQL Assistant © v7.5.502
 * Time: 01/11/2018 08:55:30
 ************************************************************/

CREATE TABLE Cliente
(
	IdCliente     INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	nome          VARCHAR(200) NOT NULL,
	email         VARCHAR(200) NOT NULL,
	senha         VARCHAR(200) NOT NULL
)