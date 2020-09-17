using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FT = 0;
            ViewBag.TT = 0;
            ViewBag.TF = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(TipCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FT = model.CalculateFT();
                ViewBag.TT = model.CalculateTT();
                ViewBag.TF = model.CalculateTF();
            }
            else
            {
                ViewBag.FT = 0;
                ViewBag.TT = 0;
                ViewBag.TF = 0;
            }
            return View(model);
        }
    }
}
