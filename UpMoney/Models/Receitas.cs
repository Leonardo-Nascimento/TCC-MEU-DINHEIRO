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

        public int Id { get; set; }

        [Required(ErrorMessage = "")]
        public int id { get; set; }
        public int idTipoReceita {get;set;}
        public decimal valor { get; set; }
        public string DescricaoReceita { get; set; }



        public bool BuscaRceitas()
        {
            DataTable dt = null;

          
                string sql = $"SELECT * from Receitas";
                DAL OBJDAL = new DAL();
                dt = OBJDAL.RetDataTable(sql);
            

         

            return true;
        }


    }
}
