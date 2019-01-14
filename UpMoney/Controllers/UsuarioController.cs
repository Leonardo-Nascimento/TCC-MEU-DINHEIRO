using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;

namespace UpMoney.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CadUsuario()
        {
            //bool cadUsuario = usuario.RegistrarUsuario();

            //if (cadUsuario)
            //{
            //    return RedirectToAction("MenuPrincipal", "Home");
            //}else
            return View();
        }

        public IActionResult ValidarLogin(UsuarioModel usuario)
        {
           
            ViewData["Nome"] = "LEO";
            //TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
            return RedirectToAction("MenuPrincipal", "Home");
            

            // bool login = usuario.ValidarLogin();
            //if (login)
            //{
            //    //HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
            //    //HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
            //    //return RedirectToAction("Menu", "Home");
            //    return RedirectToAction("MenuPrincipal","Home");

            //}
            //else
            //{
            //    //TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
            //    return RedirectToAction("CadErro");
            //}
        }

        public IActionResult LoginErro()
        {
            return View();
        }



    }
}