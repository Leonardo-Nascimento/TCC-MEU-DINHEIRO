using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;
using Newtonsoft.Json;

namespace UpMoney.Controllers
{
    public class TipoDepesasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet("/tiposReceita/{id}")]
        public JsonResult GetTiposDespesas(string idUsuario)
        {
            var  objTipoDespesa = new TipoDespesaModel();
            return Json(objTipoDespesa.retornaDespesas(idUsuario));

            //this.Json(objTipoReceita.retornaReceitas(idUsuario)); 
            //JsonConvert.SerializeObject(objTipoReceita.retornaReceitas(idUsuario));

        }

    }
}