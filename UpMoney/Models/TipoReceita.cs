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
    public class TipoReceitaModel
    {
        public int idTipoReceita { get; set; }
        public string dsTipoReceita { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public static explicit operator TipoReceitaModel(string v)
        {
            throw new NotImplementedException();
        }

        public TipoReceitaModel()
        {

        }

        public List<TipoReceitaModel> retornaReceitas(string idUsuario)
        {
            
            List<TipoReceitaModel> lista = new List<TipoReceitaModel>();
            TipoReceitaModel item;
            

            string id_usuarioLogado = idUsuario;

            string sql =   $" SELECT * FROM TipoReceita AS tr " ;

                
            try
            {

                DAL objDAL = new DAL();
                DataTable dt = objDAL.RetDataTable(sql);



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    item = new TipoReceitaModel();
                    TipoReceitaModel tipo = new TipoReceitaModel();

                    item.idTipoReceita = int.Parse(dt.Rows[i]["idTipoReceita"].ToString());
                    item.dsTipoReceita = dt.Rows[i]["DsTipoReceita"].ToString();

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