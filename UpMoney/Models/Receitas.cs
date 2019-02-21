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
        public decimal valor { get; set; }
        public string descricaoReceita { get; set; }
        public string categoriaReceita { get; set; }
        public string nomeConta { get; set; }
        public string tipoConta { get; set; }



        public IHttpContextAccessor HttpContextAccessor { get; set; }






        public Receitas()
        {

        }



        public bool BuscaRceitas()
        {
            DataTable dt = null;

          
                string sql = $"SELECT * from Receitas";
                DAL OBJDAL = new DAL();
                dt = OBJDAL.RetDataTable(sql);
            

         

            return true;
        }

        public List<Receitas> ListaReceitas()
        {
            List<Receitas> lista = new List<Receitas>();
            Receitas item;

            string id_usuarioLogado = HttpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado");
            string sql = $"SELECT cm.Data ,cm.DsReceita,tr.DsTipoReceita,cm.valorReceita,c.NomeConta,c.TipoConta" +
                        $" FROM Cliente_Movimentacao AS cm" +
                        $" JOIN TipoReceita AS tr" +
                        $"  ON tr.idTipoReceita = cm.idTipoReceita" +
                        $" JOIN Conta AS c" +
                        $"  ON cm.idCliente = c.idCliente" +
                        $" WHERE idCliente =" +
                        $"  ON tr.idTipoReceita = cm.idTipoReceita" +
                        $" JOIN Conta AS c" +
                        $"  ON cm.idCliente = c.idCliente" +
                        $" WHERE idCliente = {id_usuarioLogado}";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new Receitas();
                item.dataReceita = dt.Rows[i]["cm.Data"].ToString();
                item.descricaoReceita = dt.Rows[i]["cm.DsReceita"].ToString();
                item.categoriaReceita = dt.Rows[i]["DsTipoReceita"].ToString();
                item.valor = decimal.Parse(dt.Rows[i]["cm.valorReceita"].ToString());
                item.nomeConta = dt.Rows[i]["c.NomeConta"].ToString();
                item.tipoConta = dt.Rows[i]["c.TipoConta"].ToString();
                lista.Add(item);
            }

            return lista;
        }




    }
}
