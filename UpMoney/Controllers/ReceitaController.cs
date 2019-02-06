using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UpMoney.Controllers
{
    public class ReceitaController : Controller
    {
        public IActionResult VerReceita()
        {
            return View();
        }


        public IActionResult AdicionaReceita()
        {
            return View();
        }


        public IActionResult AdicionaTipo()
        {
            return View();
        }
    }
}