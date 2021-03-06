﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UpMoney.Util;

namespace UpMoney.Models
{
    public class ReceitasModel : TipoReceitaModel
    {

        [Required(ErrorMessage = "preencha os campos")]
        public int idReceita { get; set; }
        public int idTipoReceita { get; set; }

        public string descricaoTipoReceita { get; set; }

        public string descricaoReceita { get; set; }

        public string dataReceita {get;set;}

        public string dtInicial { get; set;}

        public string dtFinal { get; set; }

        public string valor { get; set; }        

        public string categoriaReceita { get; set; }

        public string nomeConta { get; set; }

        public string tipoConta { get; set; }

        public decimal totalReceita { get; set; }


        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public ReceitasModel()
        {

        }

        //Recebe o contexto para acesso as variaveis de sessao
        public ReceitasModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }


        public string TotalRceitas(string idUsuario)
        {
            string id_usuarioLogado = idUsuario;
            string sql = $" SELECT cm.idReceita,CONVERT(VARCHAR, r.[Data], 103) AS DATA,(SELECT SUM(Receitas.ValorReceita) FROM Receitas WHERE idClienteReceita = {id_usuarioLogado}) AS Total,r.DsReceita,tr.DsTipoReceita,tr.IdTipoReceita ,r.ValorReceita,c.NomeConta,c.TipoConta " +
                         " FROM Cliente_Movimentacao AS cm " +
                         " join Receitas AS r " +
                         " on cm.idReceita = r.idReceita" +
                         " JOIN TipoReceita AS tr" +
                         " ON tr.idTipoReceita = r.TipoReceita" +
                         " JOIN Conta AS c" +
                         " ON c.idCliente = cm.idCliente" +
                         $" WHERE cm.idCliente = {id_usuarioLogado}";

            string valorTotalReceitas = "";

            try
            {
                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                valorTotalReceitas =  dt.Rows[0]["Total"].ToString();

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return valorTotalReceitas;
        }

        //Mostra todas as Rceitas do Usuario logado
        public List<ReceitasModel> ListaReceitas(int opcao = 0)
        {

            //opção "1" = Data
            //opção "2" = Intervalo de Data
            //opção "3" = Descrição 
            //opção "4" = Valor Crescente  
            //opção "5" = Valor Decrescente


            List<ReceitasModel> lista = new List<ReceitasModel>();
            ReceitasModel item;
            string condicao = "r.Data";


            if (opcao == 1){
                condicao = "r.Data";
            }
            else if(opcao == 3)
            {
                condicao = "r.DsReceita";
            }
            else if(opcao == 4)
            {
                condicao = "r.valorReceita ASC";
            }

            else if (opcao == 5)
            {
                condicao = "r.valorReceita DESC";
            }

            // AND cm.Data BETWEEN '20/02/2019' AND '20/02/2019'

            
            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $" SELECT cm.idReceita,CONVERT(VARCHAR, r.[Data], 103) AS DATA,(SELECT SUM(Receitas.ValorReceita) FROM Receitas WHERE idClienteReceita = {id_usuarioLogado}) AS Total,r.DsReceita,tr.DsTipoReceita,tr.IdTipoReceita ,r.ValorReceita,c.NomeConta,c.TipoConta " +
                         " FROM Cliente_Movimentacao AS cm " +
                         " join Receitas AS r " +
                         " on cm.idReceita = r.idReceita" +
                         " JOIN TipoReceita AS tr" +
                         " ON tr.idTipoReceita = r.TipoReceita" +
                         " JOIN Conta AS c" +
                         " ON c.idCliente = cm.idCliente" +
                         $" WHERE cm.idCliente = {id_usuarioLogado}";

                        if (opcao == 2 && (dtInicial != null && dtFinal != null ))
                        {
                            sql = sql + " AND r.Data BETWEEN '" + dtInicial + "' AND '" + dtFinal + "'";
                        }
                        else
                        {

                            sql = sql + " GROUP BY " +
                            $"cm.idReceita,"+
                            " CONVERT(VARCHAR, r.[Data], 103),"+
                            " r.DsReceita,"+
                            " tr.DsTipoReceita,"+
                            " tr.IdTipoReceita,"+
                            " r.ValorReceita,"+
                            " c.NomeConta,"+
                            " c.TipoConta," +
                            " r.Data ORDER BY " + condicao;
                        }
            try { 

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new ReceitasModel();
                    TipoReceitaModel tipo = new TipoReceitaModel();
                    item.idReceita = int.Parse(dt.Rows[i]["idReceita"].ToString());
                    item.dataReceita = dt.Rows[i]["Data"].ToString();
                    item.descricaoReceita = dt.Rows[i]["DsReceita"].ToString();
                    item.descricaoTipoReceita = dt.Rows[i]["DsTipoReceita"].ToString();
                    item.idTipoReceita = int.Parse(dt.Rows[i]["IdTipoReceita"].ToString());                    
                    item.valor = dt.Rows[i]["valorReceita"].ToString();
                    item.totalReceita  = decimal.Parse(dt.Rows[i]["Total"].ToString()); 
                    item.nomeConta = dt.Rows[i]["NomeConta"].ToString();
                    item.tipoConta = dt.Rows[i]["TipoConta"].ToString();
                    lista.Add(item);
                }


                

            } catch(Exception e) {
                    e.Message.ToString();
            }

            return lista;
        }


        //Exclui a receita selecionada

        public void ExcluirReceitas(int id)
        {

            string sql1 = $"DELETE FROM Cliente_Movimentacao WHERE idReceita =('{id}') ";

            string sql2 = $"DELETE FROM Receitas WHERE idReceita = ('{id}') ";
            DAL objDAL = new DAL();

            objDAL.ExecutaComandoSQL(sql1);
            objDAL.ExecutaComandoSQL(sql2);
        }




        public void RegistrarReceita()
        {
            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            valor = valor.ToString().Replace(",", ".");
            bool inserido = false;
            string sql = $"INSERT INTO Receitas(TipoReceita,Data,DsReceita,ValorReceita,idClienteReceita) VALUES ({idTipoReceita }, '{ dataReceita }', '{ descricaoReceita }', { valor },{id_usuarioLogado} )";

            try
            {
                DAL objDAL = new DAL();
                objDAL.ExecutaComandoSQL(sql);
                inserido = true;

            }catch (Exception e)
            {
                e.Message.ToString();
            }

            if (inserido) {
                try
                {
                    string sql2 = $" INSERT INTO Cliente_Movimentacao " +
                                  $"  ( " +
                                  $"    [idCliente]," +
                                  $"    [idTipoDespesa]," +
                                  $"    [idDespesa]," +
                                  $"    [idTipoReceita]," +
                                  $"    [idReceita]" +
                                  $"  )" +
                                  $"   SELECT r.idClienteReceita AS idCliente," +
                                  $"          NULL AS idTipoDespesa," +
                                  $"          NULL AS idDespesa," +
                                  $"          tr.idTipoReceita AS idTipoReceita," +
                                  $"          idReceita AS idReceita" +
                                  $"   FROM   Receitas AS r" +
                                  $"          JOIN TipoReceita AS tr" +
                                  $"               ON  tr.idTipoReceita = r.TipoReceita" +
                                  $"   WHERE r.idClienteReceita = {id_usuarioLogado}" +                                  
                                  $"         AND r.idReceita IN (SELECT idReceita" +
                                  $"                          FROM   Receitas AS r2" +
                                  $"                          WHERE  r2.TipoReceita = { idTipoReceita }" +
                                  $"                                 AND CONVERT(VARCHAR, r2.[Data], 103) = '{ dataReceita }')";


                    DAL objDAL = new DAL();
                    objDAL.ExecutaComandoSQL(sql2);

                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }

            }
        }


        public void AtualizarReceita(int ReceitaID)
        {
            //string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            valor = valor.ToString().Replace(",", ".");            

            string sql = $" UPDATE Receitas " +
                         $" SET " +
                         $" TipoReceita = {idTipoReceita}"+
                         $" ,DATA = '{dataReceita}'" +
                         $" ,DsReceita = '{descricaoReceita}'" +
                         $" ,ValorReceita = { valor }" +

                         $" WHERE idReceita = " +ReceitaID; 

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
