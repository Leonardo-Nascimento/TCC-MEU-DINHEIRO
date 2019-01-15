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
            
            return View();
        }

        [HttpPost]
        public IActionResult CriarLogin(UsuarioModel usuario)
        {           

            bool cadUsuario = usuario.RegistrarUsuario();

            if (cadUsuario)
            {                
                return RedirectToAction("MenuPrincipal", "Home");
            }
            else
                return RedirectToAction("LoginErro");
        }



        public IActionResult ValidarLogin(UsuarioModel usuario)
        {

             bool login = usuario.ValidarLogin();
            
            if (login)
            {
                //TempData["NOME"] = "LEONARDO";
                HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);                
                return RedirectToAction("MenuPrincipal","Home");

            }
            else
            {
               
                return RedirectToAction("LoginErro");
                
            }
        }

        public IActionResult LoginErro()
        {
            return View();
        }
    }
}