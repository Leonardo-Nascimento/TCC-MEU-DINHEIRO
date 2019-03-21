using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpMoney.Models
{
    public class TipoReceita
    {
        public int idTipoReceita { get; set; }
        public string dsTipoReceita { get; set; }

        public static explicit operator TipoReceita(string v)
        {
            throw new NotImplementedException();
        }
    }
}
