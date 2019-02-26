INSERT INTO [BDCADASTRO].[dbo].[Cliente_Movimentacao]
           ([idCliente]
           ,[idTipoDespesa]
           ,[idDespesa]
           ,[idTipoReceita]
           ,[idReceita]
           ,[valorDespesa]
           ,[valorReceita]
           ,[DsDespesa]
           ,[DsReceita]
           ,[Data]
           ,[NomeConta]
           ,[TipoConta])
     VALUES(
           1
           ,NULL
           ,NULL
           ,2
           ,6
           ,NULL
           ,2400
           ,NULL
           ,'Meu sal�rio'
           ,'07-02-2019'
           ,'Cart�o Bradesco	Pessoal'
           ,'sAL�RIO')



INSERT INTO [BDCADASTRO].[dbo].[Cliente_Movimentacao]
  (
    [idCliente],
    [idTipoDespesa],
    [idDespesa],
    [idTipoReceita],
    [idReceita],
    [valorDespesa],
    [valorReceita],
    [DsDespesa],
    [DsReceita],
    [Data],
    [NomeConta],
    [TipoConta]
  )
VALUES
  (
    1,
    NULL,
    NULL,
    5,
    7,
    NULL,
    500,
    NULL,
    'conta polpan�a',
    '05-02-2019',
    'Cart�o Bradesco',
    'Pessoal'
  )








INSERT INTO [BDCADASTRO].[dbo].[Cliente_Movimentacao]
  (
    [idCliente],
    [idTipoDespesa],
    [idDespesa],
    [idTipoReceita],
    [idReceita],
    [valorDespesa],
    [valorReceita],
    [DsDespesa],
    [DsReceita],
    [Data],
    [NomeConta],
    [TipoConta]
  )
VALUES
  (
    1,
    NULL,
    NULL,
    5,
    8,
    NULL,
    100,
    NULL,
    'venda de pe�as',
    '07-02-2019',
    'Cart�o Bradesco',
    'Pessoal'
  )


SELECT * FROM Receitas AS r

 SELECT CONVERT(VARCHAR, cm.Data, 103)  AS DATA,
        cm.DsReceita,
        tr.DsTipoReceita,
        cm.valorReceita,
        c.NomeConta,
        c.TipoConta
 FROM   Cliente_Movimentacao           AS cm
        JOIN TipoReceita               AS tr
             ON  tr.idTipoReceita = cm.idTipoReceita
        JOIN Conta                     AS c
             ON  cm.idCliente = c.idCliente
 WHERE  c.idCliente = 1
 ORDER BY cm.valorReceita DESC