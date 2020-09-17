using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public IActionResult Index()
        {
            ViewBag.DA = 0;
            ViewBag.PT = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(PriceQuotationModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DA = model.CalculateDiscountAmount();
                ViewBag.PT = model.CalculateTotal();
            }
            else
            {
                ViewBag.DA = 0;
                ViewBag.PT = 0;
            }
            return View(model);
        }
    }
}
