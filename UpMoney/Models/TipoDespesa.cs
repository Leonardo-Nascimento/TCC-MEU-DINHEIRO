using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UpMoney.Util;
using UpMoney.Models;

namespace UpMoney.Models
{
    public class TipoDespesaModel
    {
        public int idTipoDespesa { get; set; }
        public string dsTipoDespesa { get; set; }

        public static explicit operator TipoDespesaModel(string v)
        {
            throw new NotImplementedException();
        }

        public TipoDespesaModel()
        {

        }

        public List<TipoDespesaModel> retornaDespesas(string idUsuario)
        {            
            List<TipoDespesaModel> lista = new List<TipoDespesaModel>();
            TipoDespesaModel item;            

            string id_usuarioLogado = idUsuario;
            string sql =   $" SELECT * FROM TipoDespesa AS tr" ;
                
            try
            {

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new TipoDespesaModel();
                    TipoDespesaModel tipo = new TipoDespesaModel();

                    item.idTipoDespesa = int.Parse(dt.Rows[i]["idTipoDespesa"].ToString());
                    item.dsTipoDespesa = dt.Rows[i]["DsTipoDespesa"].ToString();

                    lista.Add(item);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return lista;
        }


    }
}