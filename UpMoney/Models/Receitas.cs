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
    public class Receitas
    {

        

        [Required(ErrorMessage = "preencha os campos")]
        public int id { get; set; }

        public int idTipoReceita {get;set;}

        public string dataReceita {get;set;}

        public string dtInicial { get; set;}

        public string dtFinal { get; set; }

        public decimal valor { get; set; }

        public string descricaoReceita { get; set; }

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

        public List<Receitas> ListaReceitas(int opcao = 0)
        {

            //opção "1" = Data
            //opção "2" = Intervalo de Data
            //opção "3" = Descrição 
            //opção "4" = Valor Crescente  
            //opção "5" = Valor Decrescente


            List<Receitas> lista = new List<Receitas>();
            Receitas item;
            string condicao = "cm.Data";

            if (opcao == 1){
                condicao = "cm.Data";
            }
            else if(opcao == 3)
            {
                condicao = "cm.DsReceita";
            }
            else if(opcao == 4)
            {
                condicao = "cm.valorReceita ASC";
            }

            else if (opcao == 5)
            {
                condicao = "cm.valorReceita DESC";
            }

            // AND cm.Data BETWEEN '20/02/2019' AND '20/02/2019'


            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $" SELECT CONVERT(VARCHAR, cm.Data, 103) AS Data ,cm.DsReceita,tr.DsTipoReceita,cm.valorReceita,c.NomeConta,c.TipoConta" +
                        $" FROM Cliente_Movimentacao AS cm" +
                        $" JOIN TipoReceita AS tr" +
                        $"  ON tr.idTipoReceita = cm.idTipoReceita" +
                        $" JOIN Conta AS c" +
                        $"  ON cm.idCliente = c.idCliente" +
                        $" WHERE c.idCliente = {id_usuarioLogado}";

                        if (opcao == 2 && (dtInicial != null && dtFinal != null ))
                        {
                            sql = sql + " AND cm.Data BETWEEN '" + dtInicial + "' AND '" + dtFinal + "'";
                        }
                        else
                        {

                            sql = sql + " ORDER BY " + condicao;
                        }

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

        

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new Receitas();
                    item.dataReceita = dt.Rows[i]["Data"].ToString();
                    item.descricaoReceita = dt.Rows[i]["DsReceita"].ToString();
                    item.categoriaReceita = dt.Rows[i]["DsTipoReceita"].ToString();
                    item.valor = decimal.Parse(dt.Rows[i]["valorReceita"].ToString());
                    item.nomeConta = dt.Rows[i]["NomeConta"].ToString();
                    item.tipoConta = dt.Rows[i]["TipoConta"].ToString();
                    lista.Add(item);
                }


                return lista;
         
        }




    }
}
