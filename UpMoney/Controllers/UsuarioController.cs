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

     

        public IActionResult CriarLogin(UsuarioModel usuario)
        {
            bool CadUsuario = usuario.RegistrarUsuario();

            if (CadUsuario)
            {
                return RedirectToAction("MenuPrincipal", "Home");
            }else
                return RedirectToAction("LoginErro", "Usuario");
        }

        public IActionResult ValidarLogin(UsuarioModel usuario)
        {

             bool login = usuario.ValidarLogin();
            if (login)
            {
                //HttpContext.Session.SetString("NomeUsuarioLogado", usuario.Nome);
                //HttpContext.Session.SetString("IdUsuarioLogado", usuario.Id.ToString());
                //return RedirectToAction("Menu", "Home");
                return RedirectToAction("MenuPrincipal","Home");

            }
            else
            {
                //TempData["MensagemLoginInvalido"] = "Dados de login inválidos!";
                return RedirectToAction("CadErro");
            }
        }
    }
}