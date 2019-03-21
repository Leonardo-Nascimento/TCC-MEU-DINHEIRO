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

        IHttpContextAccessor HttpContextAccessor;

        public ReceitaController(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;

        }



        public IActionResult VerReceita()
        {

            Receitas objReceita = new Receitas(HttpContextAccessor);
            ViewBag.ListaReceitas = objReceita.ListaReceitas();
            return View();
        }

        [HttpGet]        
        public IActionResult VerReceita(int id)
        {
            var numero = id;
            Receitas objReceita = new Receitas(HttpContextAccessor);
            ViewBag.ListaReceitas = objReceita.ListaReceitas(id);

            return View();

            //return RedirectToAction("VerReceita");
        }

        [HttpGet]
        public IActionResult ExcluirReceita(int id)
        {
            var numero = id;
            Receitas objReceita = new Receitas(HttpContextAccessor);
            objReceita.ExcluirReceitas(id);



            return RedirectToAction("VerReceita");
        }


        //public IActionResult Registrar(UsuarioModel usuario)
        //{
        //    //Registra o Usuário
        //    if (ModelState.IsValid)
        //    {
        //        usuario.RegistrarUsuario();
        //        return RedirectToAction("Sucesso");
        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult AdicionaReceita(Receitas receita)
        {
            receita.RegistrarReceita();
            return View();
        }




        public IActionResult AdicionaTipo()
        {
            return View();
        }
    }
}