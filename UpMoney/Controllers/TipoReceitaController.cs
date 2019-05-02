using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;
using Newtonsoft.Json;

namespace UpMoney.Controllers
{
    public class TipoReceitaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet("/tiposReceita/{id}")]
        public JsonResult GetTiposReceitas(string idUsuario)
        {
            var  objTipoReceita = new TipoReceitaModel();
            return Json(objTipoReceita.retornaReceitas(idUsuario));

            //this.Json(objTipoReceita.retornaReceitas(idUsuario)); 
            //JsonConvert.SerializeObject(objTipoReceita.retornaReceitas(idUsuario));

        }

    }
}