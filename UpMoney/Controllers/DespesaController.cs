using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;

namespace UpMoney.Controllers
{
    public class DespesaController : Controller
    {

        IHttpContextAccessor HttpContextAccessorController;

        public DespesaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessorController = httpContextAccessor;

        }



        public IActionResult VerDespesa()
        {

            DespesasModel objDespesa = new DespesasModel(HttpContextAccessorController);
            ViewBag.ListaDespesas = objDespesa.ListaDespesas();
            return View();
        }

        [HttpGet]        
        public IActionResult VerDespesa(int id)
        {
            var numero = id;
            DespesasModel objDespesa = new DespesasModel(HttpContextAccessorController);
            
            ViewBag.ListaDespesas =  objDespesa.ListaDespesas(id).Count > 0 ? objDespesa.ListaDespesas(id) : null;

            
            return View();

            //return RedirectToAction("VerDespesa");
        }

        [HttpGet]
        public IActionResult ExcluirDespesa(int id)
        {
            var numero = id;
            DespesasModel objDespesa = new DespesasModel(HttpContextAccessorController);
            objDespesa.ExcluirDespesas(id);



            return RedirectToAction("VerDespesa");
        }


        [HttpPost]
        public IActionResult AdicionaDespesa( DespesasModel Despesa)
        {
            DespesasModel objDespesa = Despesa;
            Despesa.HttpContextAccessor = HttpContextAccessorController;

            Despesa.RegistrarDespesa(); 
            return View();
        }


        public IActionResult AdicionaTipo()
        {
            return View();
        }

        [HttpPost]
        //[Route("EditarDespesa/{idDespesa}")]
        public IActionResult EditarDespesa(DespesasModel Despesa)
        {
            if(Despesa.idDespesa != null)
            {
                Despesa.AtualizarDespesa(Despesa.idDespesa);
                HttpContext.Session.SetString("EditarDespesa", Despesa.idDespesa.ToString());

                return RedirectToAction("VerDespesa");

            }else
                 HttpContext.Session.SetString("EditarDespesa", null);

                 return RedirectToAction("VerDespesa");


        }
        


    }
}