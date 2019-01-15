﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpMoney.Models;

namespace UpMoney.Controllers
{
    public class HomeController : Controller
    {

        //public IHttpContextAccessor HttpContextAccessor { get; set; }       

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MenuPrincipal()
        {

            string nomeUsuario = HttpContext.Session.GetString("NomeUsuarioLogado");

            if (nomeUsuario != null && nomeUsuario != "")
            {
                ViewData["NOME"] = nomeUsuario;
                return View();
            }

            ViewData["NOME"] = "";
            return View();


        }

        public IActionResult Sobre()
        {         

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
