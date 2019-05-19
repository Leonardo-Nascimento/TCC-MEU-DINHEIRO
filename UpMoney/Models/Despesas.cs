using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UpMoney.Util;

namespace UpMoney.Models
{
    public class DespesasModel : TipoDespesaModel
    {

        [Required(ErrorMessage = "preencha os campos")]
        public int idDespesa { get; set; }
        public int idTipoDespesa { get; set; }

        public string descricaoTipoDespesa { get; set; }

        public string descricaoDespesa { get; set; }

        public string dataDespesa { get; set; }

        public string dtInicial { get; set; }

        public string dtFinal { get; set; }

        public string valor { get; set; }

        public string categoriaDespesa { get; set; }

        public string nomeConta { get; set; }

        public string tipoConta { get; set; }

        public decimal totalDespesa { get; set; }


        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public DespesasModel()
        {

        }

        //Recebe o contexto para acesso as variaveis de sessao
        public DespesasModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }


        public string TotalDespesas(string idUsuario)
        {
            string id_usuarioLogado = idUsuario;
            string sql = $" SELECT cm.idDespesa,CONVERT(VARCHAR, d.[Data], 103) AS DATA,(SELECT SUM(Despesas.ValorDespesa) FROM Despesas ) AS Total,d.DsDespesa,td.DsTipoDespesa,td.IdTipoDespesa ,d.ValorDespesa,c.NomeConta,c.TipoConta " +
                         " FROM Cliente_Movimentacao AS cm " +
                         " join Despesas AS d " +
                         " on cm.idDespesa = d.idDespesa" +
                         " JOIN TipoDespesa AS td" +
                         " ON td.idTipoDespesa = d.TipoDespesa" +
                         " JOIN Conta AS c" +
                         " ON c.idCliente = cm.idCliente" +
                         $" WHERE cm.idCliente = {id_usuarioLogado}";

            string valorTotalDespesas = "";

            try
            {
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                valorTotalDespesas = dt.Rows[0]["Total"].ToString();

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return valorTotalDespesas;
        }

        //Mostra todas as Rceitas do Usuario logado
        public List<DespesasModel> ListaDespesas(int opcao = 0)
        {

            //opção "1" = Data
            //opção "2" = Intervalo de Data
            //opção "3" = Descrição 
            //opção "4" = Valor Crescente  
            //opção "5" = Valor Decrescente


            List<DespesasModel> lista = new List<DespesasModel>();
            DespesasModel item;
            string condicao = "r.Data";


            if (opcao == 1)
            {
                condicao = "r.Data";
            }
            else if (opcao == 3)
            {
                condicao = "r.DsDespesa";
            }
            else if (opcao == 4)
            {
                condicao = "r.valorDespesa ASC";
            }

            else if (opcao == 5)
            {
                condicao = "r.valorDespesa DESC";
            }

            // AND cm.Data BETWEEN '20/02/2019' AND '20/02/2019'


            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $" SELECT cm.idDespesa,CONVERT(VARCHAR, r.[Data], 103) AS DATA,(SELECT SUM(Despesas.ValorDespesa) FROM Despesas ) AS Total,r.DsDespesa,tr.DsTipoDespesa,tr.IdTipoDespesa ,r.ValorDespesa,c.NomeConta,c.TipoConta " +
                         " FROM Cliente_Movimentacao AS cm " +
                         " join Despesas AS r " +
                         " on cm.idDespesa = r.idDespesa" +
                         " JOIN TipoDespesa AS tr" +
                         " ON tr.idTipoDespesa = r.TipoDespesa" +
                         " JOIN Conta AS c" +
                         " ON c.idCliente = cm.idCliente" +
                         $" WHERE cm.idCliente = {id_usuarioLogado}";

            if (opcao == 2 && (dtInicial != null && dtFinal != null))
            {
                sql = sql + " AND r.Data BETWEEN '" + dtInicial + "' AND '" + dtFinal + "'";
            }
            else
            {

                sql = sql + " GROUP BY " +
                $"cm.idDespesa," +
                " CONVERT(VARCHAR, r.[Data], 103)," +
                " r.DsDespesa," +
                " tr.DsTipoDespesa," +
                " tr.IdTipoDespesa," +
                " r.ValorDespesa," +
                " c.NomeConta," +
                " c.TipoConta," +
                " r.Data ORDER BY " + condicao;
            }
            try
            {

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new DespesasModel();
                    TipoDespesaModel tipo = new TipoDespesaModel();
                    item.idDespesa = int.Parse(dt.Rows[i]["idDespesa"].ToString());
                    item.dataDespesa = dt.Rows[i]["Data"].ToString();
                    item.descricaoDespesa = dt.Rows[i]["DsDespesa"].ToString();
                    item.descricaoTipoDespesa = dt.Rows[i]["DsTipoDespesa"].ToString();
                    item.idTipoDespesa = int.Parse(dt.Rows[i]["IdTipoDespesa"].ToString());
                    item.valor = dt.Rows[i]["valorDespesa"].ToString();
                    item.totalDespesa = decimal.Parse(dt.Rows[i]["Total"].ToString());
                    item.nomeConta = dt.Rows[i]["NomeConta"].ToString();
                    item.tipoConta = dt.Rows[i]["TipoConta"].ToString();
                    lista.Add(item);
                }




            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return lista;
        }

        //Exclui a Despesa selecionada

        public void ExcluirDespesas(int id)
        {

            string sql1 = $"DELETE FROM Cliente_Movimentacao WHERE idDespesa =('{id}') ";

            string sql2 = $"DELETE FROM Despesas WHERE idDespesa = ('{id}') ";
            DAL objDAL = new DAL();

            objDAL.ExecutaComandoSQL(sql1);
            objDAL.ExecutaComandoSQL(sql2);
        }




        public void RegistrarDespesa()
        {
            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            valor = valor.ToString().Replace(",", ".");
            bool inserido = false;
            string sql = $"INSERT INTO Despesas(TipoDespesa,Data,DsDespesa,ValorDespesa,idClienteDespesa) VALUES ( { idTipoDespesa }, '{ dataDespesa }', '{ descricaoDespesa }', { valor }, {id_usuarioLogado} )";

            try
            {
                DAL objDAL = new DAL();
                objDAL.ExecutaComandoSQL(sql);
                inserido = true;

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            if (inserido)
            {
                try
                {
                    string sql2 = $" INSERT INTO Cliente_Movimentacao " +
                                  $"  ( " +
                                  $"    [idCliente]," +
                                  $"    [idTipoDespesa]," +
                                  $"    [idDespesa]," +
                                  $"    [idTipoReceita]," +
                                  $"    [idReceita] "+
                                  $"  )" +
                                  $"   SELECT   d.idClienteDespesa AS idCliente," +
                                  $"            tr.idTipoDespesa  AS idTipoDespesa," +
                                  $"            d.idDespesa       AS idDespesa ," +
                                  $"            NULL              AS idTipoReceita,"+
                                  $"            NULL              AS idReceita" +
                                  $"   FROM   Despesas AS d" +
                                  $"          JOIN TipoDespesa AS tr" +
                                  $"               ON  tr.idTipoDespesa = d.TipoDespesa" +                                             
                                  $"   WHERE d.idClienteDespesa = {id_usuarioLogado}" +
                                  $"         AND d.idDespesa IN (SELECT idDespesa" +
                                  $"                          FROM   Despesas AS d2" +
                                  $"                          WHERE  d2.TipoDespesa = { idTipoDespesa }" +
                                  $"                                 AND CONVERT(VARCHAR, d2.[Data], 103) = '{ dataDespesa }')";


                    DAL objDAL = new DAL();
                    objDAL.ExecutaComandoSQL(sql2);

                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }
        }


        public void AtualizarDespesa(int DespesaID)
        {
            //string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            valor = valor.ToString().Replace(",", ".");

            string sql = $" UPDATE Despesas " +
                         $" SET " +
                         $" TipoDespesa = {idTipoDespesa}" +
                         $" ,DATA = '{dataDespesa}'" +
                         $" ,DsDespesa = '{descricaoDespesa}'" +
                         $" ,ValorDespesa = { valor }" +

                         $" WHERE idDespesa = " + DespesaID;

            try
            {
                DAL objDAL = new DAL();
                objDAL.ExecutaComandoSQL(sql);
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }


        }

    }


}
