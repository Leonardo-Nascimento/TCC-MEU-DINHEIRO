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
    public class Receitas: TipoReceita
    {        

        [Required(ErrorMessage = "preencha os campos")]
        public int id { get; set; }

        public TipoReceita idTipoReceita { get;set;}
        public TipoReceita descricaoTipoReceita { get; set; }

        public string descricaoReceita { get; set; }

        public string dataReceita {get;set;}

        public string dtInicial { get; set;}

        public string dtFinal { get; set; }

        public decimal valor { get; set; }        

        public string categoriaReceita { get; set; }

        public string nomeConta { get; set; }

        public string tipoConta { get; set; }



        public IHttpContextAccessor HttpContextAccessor { get; set; }


        public Receitas()
        {

        }

        //Recebe o contexto para acesso as variaveis de sessao
        public Receitas(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }


        public bool BuscaRceitas()
        {
            DataTable dt = null;

          
                string sql = $"SELECT * from Receitas";
                DAL OBJDAL = new DAL();
                dt = OBJDAL.RetDataTable(sql);
            

         

            return true;
        }

        //Mostra todas as Rceitas do Usuario logado
        public List<Receitas> ListaReceitas(int opcao = 0)
        {

            //opção "1" = Data
            //opção "2" = Intervalo de Data
            //opção "3" = Descrição 
            //opção "4" = Valor Crescente  
            //opção "5" = Valor Decrescente


            List<Receitas> lista = new List<Receitas>();
            Receitas item;
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
            string sql = $" SELECT cm.idReceita,CONVERT(VARCHAR, r.[Data], 103) AS DATA,r.DsReceita,tr.DsTipoReceita,r.ValorReceita,c.NomeConta,c.TipoConta " +
                         $" FROM Cliente_Movimentacao AS cm " +
                         $" join Receitas AS r " +
                         $" on cm.idReceita = r.idReceita" +
                         $" JOIN TipoReceita AS tr" +
                         $" ON tr.idTipoReceita = r.TipoReceita" +
                         $" JOIN Conta AS c" +
                         $" ON c.idCliente = cm.idCliente"; 
                        //$" WHERE cm.idCliente = {id_usuarioLogado}";

                        if (opcao == 2 && (dtInicial != null && dtFinal != null ))
                        {
                            sql = sql + " AND r.Data BETWEEN '" + dtInicial + "' AND '" + dtFinal + "'";
                        }
                        else
                        {

                            sql = sql + " ORDER BY " + condicao;
                        }
            try { 

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Receitas();
                    TipoReceita tipo = new TipoReceita();
                    item.id = int.Parse(dt.Rows[i]["idReceita"].ToString());
                    item.dataReceita = dt.Rows[i]["Data"].ToString();
                    item.descricaoTipoReceita = (TipoReceita) dt.Rows[i]["DsReceita"].ToString();
                    item.valor = decimal.Parse(dt.Rows[i]["valorReceita"].ToString());
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
            
            string sql = $"INSERT INTO Receitas(TipoReceita,Data,DsReceita,ValorReceita) VALUES ( { descricaoTipoReceita }, { dataReceita }, { descricaoReceita }, { valor } )";
            DAL objDAL = new DAL();
            objDAL.ExecutaComandoSQL(sql);


        }
    }
}
