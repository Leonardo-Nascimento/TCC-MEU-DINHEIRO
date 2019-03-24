using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;

namespace UpMoney.Controllers
{
    public class ReceitaController : Controller
    {

        IHttpContextAccessor HttpContextAccessorController;

        public ReceitaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessorController = httpContextAccessor;

        }



        public IActionResult VerReceita()
        {

            ReceitasModel objReceita = new ReceitasModel(HttpContextAccessorController);
            ViewBag.ListaReceitas = objReceita.ListaReceitas();
            return View();
        }

        [HttpGet]        
        public IActionResult VerReceita(int id)
        {
            var numero = id;
            ReceitasModel objReceita = new ReceitasModel(HttpContextAccessorController);
            ViewBag.ListaReceitas = objReceita.ListaReceitas(id);

            return View();

            //return RedirectToAction("VerReceita");
        }

        [HttpGet]
        public IActionResult ExcluirReceita(int id)
        {
            var numero = id;
            ReceitasModel objReceita = new ReceitasModel(HttpContextAccessorController);
            objReceita.ExcluirReceitas(id);



            return RedirectToAction("VerReceita");
        }


        [HttpPost]
        public IActionResult AdicionaReceita( ReceitasModel receita)
        {
            ReceitasModel objReceita = receita;
            receita.HttpContextAccessor = HttpContextAccessorController;
            receita.RegistrarReceita(); 
            return View();
        }


        public IActionResult AdicionaTipo()
        {
            return View();
        }
    }
}