﻿
using BiblioPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiblioPortal.Controllers
{
    public class OutilsController : Controller
    {
        //GET: Outils/Random
        public IActionResult Random()
        {
            var outil = new Outil() { name = "Marteau" };

            return View(outil);
        }
    }
}
