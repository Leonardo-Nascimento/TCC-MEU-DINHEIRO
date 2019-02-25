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
 WHERE  c.idCliente = 